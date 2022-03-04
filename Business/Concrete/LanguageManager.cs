using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        [SecuredOperation("language.add,admin")]
        [ValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect("ILanguageService.Get")]
        public async Task<IResult> AddAsync(Language language, string createdByName)
        {
            language.CreatedByName = createdByName;
            language.ModifiedByName = createdByName;
            await _languageDal.AddAsync(language);
            return new SuccessResult(Messages.Language.languageAdded);
        }

        public async Task<IResult> DeleteAsync(int languageId, string modifiedByName)
        {
            var result = await _languageDal.AnyAsync(l => l.Id == languageId);
            if (result)
            {
                var language = await _languageDal.GetAsync(l => l.Id == languageId);
                language.IsActive = false;
                language.ModifiedByName = modifiedByName;
                language.ModifiedDate = DateTime.Now;
                await _languageDal.UpdateAsync(language);
                return new SuccessResult(Messages.Language.languageDeleted);
            }
            return new ErrorResult(Messages.Language.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<Language>>> GetAllAsync()
        {
            var languages = await _languageDal.GetAllAsync();
            if (languages.Count > -1)
            {
                return new SuccessDataResult<List<Language>>();
            }
            return new ErrorDataResult<List<Language>>(Messages.Language.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<Language>>> GetAllByNonDeletedAndActiveAsync()
        {
            var languages = await _languageDal.GetAllAsync(l => !l.IsDeleted && l.IsActive);
            if (languages.Count > -1)
            {
                return new SuccessDataResult<List<Language>>();
            }
            return new ErrorDataResult<List<Language>>(Messages.Language.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<Language>>> GetAllByNonDeletedAsync()
        {
            var languages = await _languageDal.GetAllAsync(l => !l.IsDeleted);
            if (languages.Count > -1)
            {
                return new SuccessDataResult<List<Language>>();
            }
            return new ErrorDataResult<List<Language>>(Messages.Language.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<Language>> GetAsync(int languageId)
        {
            var language = await _languageDal.GetAsync(l => l.Id == languageId);
            if (language != null)
            {
                return new SuccessDataResult<Language>();
            }
            return new ErrorDataResult<Language>(Messages.Language.NotFound(isPlural: true));
        }

        public async Task<IResult> HardDeleteAsync(int languageId)
        {
            var result = await _languageDal.AnyAsync(l => l.Id == languageId);
            if (result)
            {
                var language = await _languageDal.GetAsync(l => l.Id == languageId);
                await _languageDal.DeleteAsync(language);
                return new SuccessResult(Messages.Language.languageHardDeleted);
            }
            return new SuccessResult(Messages.Language.NotFound(isPlural: false));
        }

        [SecuredOperation("language.update,admin")]
        [ValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect("ILanguageService.Get")]
        public async Task<IResult> UpdateAsync(Language language, string modifiedByName)
        {
            var oldLanguage = await _languageDal.GetAsync(l => l.Id == language.Id);
            oldLanguage.ModifiedByName = modifiedByName;
            var updatedLanguage = await _languageDal.UpdateAsync(oldLanguage);
            return new SuccessResult(Messages.Language.languageUpdated);
        }
    }
}
