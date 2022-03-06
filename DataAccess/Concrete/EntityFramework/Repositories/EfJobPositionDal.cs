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
    public class EfJobPositionDal : EfEntityRepositoryBase<JobPosition>, IJobPositionDal
    {
        public EfJobPositionDal(DbContext context) : base(context)
        {
        }

        public async Task<JobPosition> GetByTitle(string title)
        {
            return await HrmsContext.JobPositions.SingleOrDefaultAsync(j => j.Title == title);
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
