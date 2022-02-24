using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmailActivationService
    {
        Task<IDataResult<EmailActivation>> GetAsync(int emailActivationId);
        Task<IDataResult<List<EmailActivation>>> GetAllAsync();
        Task<IDataResult<List<EmailActivation>>> GetAllByNonDeletedAsync();
        Task<IDataResult<List<EmailActivation>>> GetAllByNonDeletedAndActiveAsync();
        Task<IResult> AddAsync(EmailActivation emailActivation, string createdByName);
        Task<IResult> UpdateAsync(EmailActivation emailActivation, string modifiedByName);
        Task<IResult> DeleteAsync(int emailActivationId, string modifiedByName);
        Task<IResult> HardDeleteAsync(int emailActivationId);
    }
}
