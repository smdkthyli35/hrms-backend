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
    public interface ILanguageService
    {
        Task<IDataResult<LanguageDto>> GetAsync(int languageId);
        Task<IDataResult<LanguageListDto>> GetAllAsync();
        Task<IDataResult<LanguageListDto>> GetAllByNonDeletedAsync();
        Task<IDataResult<LanguageListDto>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(LanguageAddDto languageAddDto, string createdByName);
        Task<IResult> UpdateAsync(LanguageUpdateDto languageUpdateDto, string modifiedByName);
        Task<IResult> DeleteAsync(int languageId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int languageId);
    }
}
