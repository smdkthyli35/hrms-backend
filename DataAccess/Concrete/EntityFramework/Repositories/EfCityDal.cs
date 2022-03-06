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
    public class EfCityDal : EfEntityRepositoryBase<City>, ICityDal
    {
        public EfCityDal(DbContext context) : base(context)
        {
        }

        public async Task<City> GetByName(string name)
        {
            return await HrmsContext.Cities.SingleOrDefaultAsync(c => c.Name == name);
        }

        public async Task<List<City>> GetByNameContains(string name)
        {
            return await HrmsContext.Cities.Where(c => c.Name == name).ToListAsync();
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
