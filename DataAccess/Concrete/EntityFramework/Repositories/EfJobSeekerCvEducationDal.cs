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
    public class EfJobSeekerCvEducationDal : EfEntityRepositoryBase<JobSeekerCvEducation>, IJobSeekerCvEducationDal
    {
        public EfJobSeekerCvEducationDal(DbContext context) : base(context)
        {
        }

        public async Task<List<JobSeekerCvEducation>> GetListByJobSeekerCvId(int jobSeekerCvId)
        {
            return await HrmsContext.JobSeekerCvEducations.Where(j => j.JobSeekerCvId == jobSeekerCvId).ToListAsync();
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
