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
    public class EfJobSeekerCvWebSiteDal : EfEntityRepositoryBase<JobSeekerCvWebSite>, IJobSeekerCvWebSiteDal
    {
        public EfJobSeekerCvWebSiteDal(DbContext context) : base(context)
        {
        }

        public async Task<List<JobSeekerCvWebSite>> GetListByJobSeekerCvId(int jobSeekerCvId)
        {
            return await HrmsContext.JobSeekerCvWebSites.Where(j => j.JobSeekerCvId == jobSeekerCvId).ToListAsync();
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
