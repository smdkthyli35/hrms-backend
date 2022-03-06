using AutoMapper;
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
using Entities.Dtos;
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
        private readonly IMapper _mapper;

        public LanguageManager(ILanguageDal languageDal, IMapper mapper)
        {
            _languageDal = languageDal;
            _mapper = mapper;
        }

        [SecuredOperation("language.add,admin")]
        [ValidationAspect(typeof(LanguageValidator))]
        [CacheRemoveAspect("ILanguageService.Get")]
        public async Task<IResult> AddAsync(LanguageAddDto languageAddDto, string createdByName)
        {
            var language = _mapper.Map<Language>(languageAddDto);
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
        public async Task<IDataResult<LanguageListDto>> GetAllAsync()
        {
            var languages = await _languageDal.GetAllAsync();
            if (languages.Count > -1)
            {
                return new SuccessDataResult<LanguageListDto>(new LanguageListDto
                {
                    Languages = languages
                });
            }
            return new ErrorDataResult<LanguageListDto>(Messages.Language.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<LanguageListDto>> GetAllByNonDeletedAndActiveAsync()
        {
            var languages = await _languageDal.GetAllAsync(l => !l.IsDeleted && l.IsActive);
            if (languages.Count > -1)
            {
                return new SuccessDataResult<LanguageListDto>(new LanguageListDto
                {
                    Languages = languages
                });
            }
            return new ErrorDataResult<LanguageListDto>(Messages.Language.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<LanguageListDto>> GetAllByNonDeletedAsync()
        {
            var languages = await _languageDal.GetAllAsync(l => !l.IsDeleted);
            if (languages.Count > -1)
            {
                return new SuccessDataResult<LanguageListDto>(new LanguageListDto
                {
                    Languages = languages
                });
            }
            return new ErrorDataResult<LanguageListDto>(Messages.Language.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<LanguageDto>> GetAsync(int languageId)
        {
            var language = await _languageDal.GetAsync(l => l.Id == languageId);
            if (language != null)
            {
                return new SuccessDataResult<LanguageDto>(new LanguageDto
                {
                    Language = language
                });
            }
            return new ErrorDataResult<LanguageDto>(Messages.Language.NotFound(isPlural: false));
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
        public async Task<IResult> UpdateAsync(LanguageUpdateDto languageUpdateDto, string modifiedByName)
        {
            var oldLanguage = await _languageDal.GetAsync(l => l.Id == languageUpdateDto.Id);
            var language = _mapper.Map<LanguageUpdateDto, Language>(languageUpdateDto, oldLanguage);
            language.ModifiedByName = modifiedByName;
            await _languageDal.UpdateAsync(language);
            return new SuccessResult(Messages.Language.languageUpdated);
        }
    }
}
