using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CityManager>().As<ICityService>().SingleInstance();
            builder.RegisterType<EfCityDal>().As<ICityDal>().SingleInstance();

            builder.RegisterType<CompanyStaffManager>().As<ICompanyStaffService>().SingleInstance();
            builder.RegisterType<EfCompanyStaffDal>().As<ICompanyStaffDal>().SingleInstance();

            builder.RegisterType<EmployerManager>().As<IEmployerService>().SingleInstance();
            builder.RegisterType<EfEmployerDal>().As<IEmployerDal>().SingleInstance();

            builder.RegisterType<JobAdvertManager>().As<IJobAdvertService>().SingleInstance();
            builder.RegisterType<EfJobAdvertDal>().As<IJobAdvertDal>().SingleInstance();

            builder.RegisterType<JobPositionManager>().As<IJobPositionService>().SingleInstance();
            builder.RegisterType<EfJobPositionDal>().As<IJobPositionDal>().SingleInstance();

            builder.RegisterType<JobSeekerCvEducationManager>().As<IJobSeekerCvEducationService>().SingleInstance();
            builder.RegisterType<EfJobSeekerCvEducationDal>().As<IJobSeekerCvEducationDal>().SingleInstance();

            builder.RegisterType<JobSeekerCvExperienceManager>().As<IJobSeekerCvExperienceService>().SingleInstance();
            builder.RegisterType<EfJobSeekerCvExperienceDal>().As<IJobSeekerCvExperienceDal>().SingleInstance();

            builder.RegisterType<JobSeekerCvImageManager>().As<IJobSeekerCvImageService>().SingleInstance();
            builder.RegisterType<EfJobSeekerCvImageDal>().As<IJobSeekerCvImageDal>().SingleInstance();

            builder.RegisterType<JobSeekerCvLanguageManager>().As<IJobSeekerCvLanguageService>().SingleInstance();
            builder.RegisterType<EfJobSeekerCvLanguageDal>().As<IJobSeekerCvLanguageDal>().SingleInstance();

            builder.RegisterType<JobSeekerCvManager>().As<IJobSeekerCvService>().SingleInstance();
            builder.RegisterType<EfJobSeekerCvDal>().As<IJobSeekerCvDal>().SingleInstance();

            builder.RegisterType<JobSeekerCvSkillManager>().As<IJobSeekerCvSkillService>().SingleInstance();
            builder.RegisterType<EfJobSeekerCvSkillDal>().As<IJobSeekerCvSkillDal>().SingleInstance();

            builder.RegisterType<JobSeekerCvWebSiteManager>().As<IJobSeekerCvWebSiteService>().SingleInstance();
            builder.RegisterType<EfJobSeekerCvWebSiteDal>().As<IJobSeekerCvWebSiteDal>().SingleInstance();

            builder.RegisterType<JobSeekerManager>().As<IJobSeekerService>().SingleInstance();
            builder.RegisterType<EfJobSeekerDal>().As<IJobSeekerDal>().SingleInstance();

            builder.RegisterType<LanguageManager>().As<ILanguageService>().SingleInstance();
            builder.RegisterType<EfLanguageDal>().As<ILanguageDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<WebSiteManager>().As<IWebSiteService>().SingleInstance();
            builder.RegisterType<EfWebSiteDal>().As<IWebSiteDal>().SingleInstance();

            builder.RegisterType<WorkingTimeManager>().As<IWorkingTimeService>().SingleInstance();
            builder.RegisterType<EfWorkingTimeDal>().As<IWorkingTimeDal>().SingleInstance();

            builder.RegisterType<WorkingTypeManager>().As<IWorkingTypeService>().SingleInstance();
            builder.RegisterType<EfWorkingTypeDal>().As<IWorkingTypeDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
