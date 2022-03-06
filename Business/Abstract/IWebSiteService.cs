using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IWebSiteService
    {
        Task<IDataResult<WebSiteDto>> GetAsync(int webSiteId);
        Task<IDataResult<WebSiteDto>> GetByNameAsync(string name);
        Task<IDataResult<WebSiteListDto>> GetAllAsync();
        Task<IDataResult<WebSiteListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<WebSiteListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(WebSiteAddDto webSiteAddDto, string createdByName);
        Task<IResult> UpdateAsync(WebSiteUpdateDto webSiteUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int webSiteId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int webSiteId);
    }
}
