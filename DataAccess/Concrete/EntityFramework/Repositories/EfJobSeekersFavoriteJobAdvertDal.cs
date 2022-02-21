using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfJobSeekersFavoriteJobAdvertDal : EfEntityRepositoryBase<JobSeekersFavoriteJobAdvert>, IJobSeekersFavoriteJobAdvertDal
    {
        public EfJobSeekersFavoriteJobAdvertDal(DbContext context) : base(context)
        {
        }
    }
}
