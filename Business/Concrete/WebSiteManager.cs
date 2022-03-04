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
    public class WebSiteManager : IWebSiteService
    {
        private readonly IWebSiteDal _webSiteDal;

        public WebSiteManager(IWebSiteDal webSiteDal)
        {
            _webSiteDal = webSiteDal;
        }

        [SecuredOperation("website.add,admin")]
        [ValidationAspect(typeof(WebSiteValidator))]
        [CacheRemoveAspect("IWebSiteService.Get")]
        public async Task<IResult> AddAsync(WebSite webSite, string createdByName)
        {
            webSite.CreatedByName = createdByName;
            webSite.ModifiedByName = createdByName;
            await _webSiteDal.AddAsync(webSite);
            return new SuccessResult(Messages.WebSite.webSiteAdded);
        }

        public async Task<IResult> DeleteAsync(int webSiteId, string modifiedByName)
        {
            var result = await _webSiteDal.AnyAsync(w => w.Id == webSiteId);
            if (result)
            {
                var webSite = await _webSiteDal.GetAsync(w => w.Id == webSiteId);
                webSite.IsActive = false;
                webSite.ModifiedByName = modifiedByName;
                webSite.ModifiedDate = DateTime.Now;
                await _webSiteDal.UpdateAsync(webSite);
                return new SuccessResult(Messages.WebSite.webSiteDeleted);
            }
            return new ErrorResult(Messages.WebSite.NotFound(isPlural: false));
        }

        [CacheAspect]
        public async Task<IDataResult<List<WebSite>>> GetAllAsync()
        {
            var webSites = await _webSiteDal.GetAllAsync();
            if (webSites.Count > -1)
            {
                return new SuccessDataResult<List<WebSite>>();
            }
            return new ErrorDataResult<List<WebSite>>(Messages.WebSite.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<WebSite>>> GetAllByNonDeletedAndActiveAsync()
        {
            var webSites = await _webSiteDal.GetAllAsync(w => !w.IsDeleted && w.IsActive);
            if (webSites.Count > -1)
            {
                return new SuccessDataResult<List<WebSite>>();
            }
            return new ErrorDataResult<List<WebSite>>(Messages.WebSite.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<List<WebSite>>> GetAllByNonDeletedAsync()
        {
            var webSites = await _webSiteDal.GetAllAsync(w => !w.IsDeleted);
            if (webSites.Count > -1)
            {
                return new SuccessDataResult<List<WebSite>>();
            }
            return new ErrorDataResult<List<WebSite>>(Messages.WebSite.NotFound(isPlural: true));
        }

        [CacheAspect]
        public async Task<IDataResult<WebSite>> GetAsync(int webSiteId)
        {
            var webSite = await _webSiteDal.GetAsync(w => w.Id == webSiteId);
            if (webSite != null)
            {
                return new SuccessDataResult<WebSite>();
            }
            return new ErrorDataResult<WebSite>(Messages.WebSite.NotFound(isPlural: true));
        }

        public async Task<IResult> HardDeleteAsync(int webSiteId)
        {
            var result = await _webSiteDal.AnyAsync(w => w.Id == webSiteId);
            if (result)
            {
                var webSite = await _webSiteDal.GetAsync(w => w.Id == webSiteId);
                await _webSiteDal.DeleteAsync(webSite);
                return new SuccessResult(Messages.WebSite.webSiteHardDeleted);
            }
            return new SuccessResult(Messages.WebSite.NotFound(isPlural: false));
        }

        [SecuredOperation("website.update,admin")]
        [ValidationAspect(typeof(WebSiteValidator))]
        [CacheRemoveAspect("IWebSiteService.Get")]
        public async Task<IResult> UpdateAsync(WebSite webSite, string modifiedByName)
        {
            var oldWebSite = await _webSiteDal.GetAsync(w => w.Id == webSite.Id);
            oldWebSite.ModifiedByName = modifiedByName;
            var updatedWebSite = await _webSiteDal.UpdateAsync(oldWebSite);
            return new SuccessResult(Messages.WebSite.webSiteUpdated);
        }
    }
}
