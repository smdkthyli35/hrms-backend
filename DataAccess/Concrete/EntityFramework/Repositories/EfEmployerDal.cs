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
    public class EfEmployerDal : EfEntityRepositoryBase<Employer>, IEmployerDal
    {
        public EfEmployerDal(DbContext context) : base(context)
        {
        }

        public async Task<Employer> GetByCorporateEmail(string corporateEmail)
        {
            return await HrmsContext.Employers.SingleOrDefaultAsync(e => e.CorporateEmail == corporateEmail);
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
