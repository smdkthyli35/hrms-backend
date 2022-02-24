using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        Task<IDataResult<Language>> GetAsync(int languageId);
        Task<IDataResult<List<Language>>> GetAllAsync();
        Task<IDataResult<List<Language>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<Language>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(Language language, string createdByName);
        Task<IResult> UpdateAsync(Language language, string modifiedByName);
        Task<IResult> DeleteAsync(int languageId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int languageId);
    }
}
