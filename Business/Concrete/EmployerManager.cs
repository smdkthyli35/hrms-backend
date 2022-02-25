using Business.Abstract;
using Business.Constants;
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
    public class EmployerManager : IEmployerService
    {
        private readonly IEmployerDal _employerDal;

        public EmployerManager(IEmployerDal employerDal)
        {
            _employerDal = employerDal;
        }

        public async Task<IResult> AddAsync(Employer employer, string createdByName)
        {
            employer.CreatedByName = createdByName;
            employer.ModifiedByName = createdByName;
            await _employerDal.AddAsync(employer);
            return new SuccessResult(Messages.Employer.Add(employer.User.FirstName, employer.User.LastName));
        }

        public async Task<IResult> DeleteAsync(int employerId, string modifiedByName)
        {
            var result = await _employerDal.AnyAsync(e => e.Id == employerId);
            if (result)
            {
                var employer = await _employerDal.GetAsync(e => e.Id == employerId);
                employer.IsDeleted = true;
                employer.ModifiedByName = modifiedByName;
                employer.ModifiedDate = DateTime.Now;
                await _employerDal.UpdateAsync(employer);
                return new SuccessResult(Messages.Employer.Delete(employer.User.FirstName, employer.User.LastName));
            }
            return new ErrorResult(Messages.Employer.NotFound(isPlural: false));
        }

        public async Task<IDataResult<List<Employer>>> GetAllAsync()
        {
            var employers = await _employerDal.GetAllAsync(null, e => e.User);
            if (employers.Count > -1)
            {
                return new SuccessDataResult<List<Employer>>();
            }
            return new ErrorDataResult<List<Employer>>(Messages.Employer.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<Employer>>> GetAllByNonDeletedAndActiveAsync()
        {
            var employers = await _employerDal.GetAllAsync(e => !e.IsDeleted && e.IsActive, e => e.User);
            if (employers.Count > -1)
            {
                return new SuccessDataResult<List<Employer>>();
            }
            return new ErrorDataResult<List<Employer>>(Messages.Employer.NotFound(isPlural: true));
        }

        public async Task<IDataResult<List<Employer>>> GetAllByNonDeletedAsync()
        {
            var employers = await _employerDal.GetAllAsync(e => !e.IsDeleted, e => e.User);
            if (employers.Count > -1)
            {
                return new SuccessDataResult<List<Employer>>();
            }
            return new ErrorDataResult<List<Employer>>(Messages.Employer.NotFound(isPlural: true));
        }

        public async Task<IDataResult<Employer>> GetAsync(int employerId)
        {
            var employer = await _employerDal.GetAsync(e => e.Id == employerId, e => e.User);
            if (employer != null)
            {
                return new SuccessDataResult<Employer>();
            }
            return new ErrorDataResult<Employer>(Messages.Employer.NotFound(isPlural: true));
        }

        public async Task<IResult> HardDeleteAsync(int employerId)
        {
            var result = await _employerDal.AnyAsync(e => e.Id == employerId);
            if (result)
            {
                var employer = await _employerDal.GetAsync(e => e.Id == employerId);
                await _employerDal.DeleteAsync(employer);
                return new SuccessResult(Messages.Employer.HardDelete(employer.User.FirstName, employer.User.LastName));
            }
            return new ErrorResult(Messages.Employer.NotFound(isPlural: false));
        }

        public async Task<IResult> UpdateAsync(Employer employer, string modifiedByName)
        {
            var oldEmployer = await _employerDal.GetAsync(e => e.Id == employer.Id);
            oldEmployer.ModifiedByName = modifiedByName;
            var updatedEmployer = await _employerDal.UpdateAsync(oldEmployer);
            return new SuccessResult(Messages.Employer.Update(updatedEmployer.User.FirstName, updatedEmployer.User.LastName));
        }
    }
}
