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
    public class EfWebSiteDal : EfEntityRepositoryBase<WebSite>, IWebSiteDal
    {
        public EfWebSiteDal(DbContext context) : base(context)
        {
        }

        public async Task<WebSite> GetByName(string name)
        {
            return await HrmsContext.WebSites.SingleOrDefaultAsync(w => w.Name == name);
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
