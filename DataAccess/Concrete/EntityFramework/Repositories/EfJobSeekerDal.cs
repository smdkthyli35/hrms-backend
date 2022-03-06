using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfJobSeekerDal : EfEntityRepositoryBase<JobSeeker>, IJobSeekerDal
    {
        public EfJobSeekerDal(DbContext context) : base(context)
        {
        }

        public async Task<JobSeeker> GetByIdentityNumber(string identityNumber)
        {
            return await HrmsContext.JobSeekers.SingleOrDefaultAsync(j => j.IdentityNumber == identityNumber);
        }

        private HrmsContext HrmsContext
        {
            get
            {
                return _context as HrmsContext;
            }
        }
    }
}
