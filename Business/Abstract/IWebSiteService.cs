using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWebSiteService
    {
        Task<IDataResult<WebSite>> GetAsync(int webSiteId);
        Task<IDataResult<List<WebSite>>> GetAllAsync();
        Task<IDataResult<List<WebSite>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<WebSite>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(WebSite webSite, string createdByName);
        Task<IResult> UpdateAsync(WebSite webSite, string modifiedByName);
        Task<IResult> DeleteAsync(int webSiteId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int webSiteId);
    }
}
