using System;
using System.Data.Entity;
using IdentitySample.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using TeamProgrammer.UniversityManagement.Business.Business;
using TeamProgrammer.UniversityManagement.Core.Business_Interface;
using TeamProgrammer.UniversityManagement.Core.Repository_Interface;
using TeamProgrammer.UniversityManagement.DataRepository.Context;
using TeamProgrammer.UniversityManagement.DataRepository.Repository;
using TeamProgrammer.UniversityManagement.Web.Controllers.Identity;

namespace TeamProgrammer.UniversityManagement.Web
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();

            container.RegisterType<DbContext, UniversityDbContext>();
            container.RegisterType<IdentityDbContext<ApplicationUser>, ApplicationDbContext>();


            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IDepartmentBusiness, DepartmentBusiness>();

            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IStudentBusiness, StudentBusiness>();

            container.RegisterType<ICourseRepository, CourseRepository>();
            container.RegisterType<ICourseBusiness, CourseBusiness>();

            container.RegisterType<ISemesterRepository, SemesterRepository>();
            container.RegisterType<ISemesterBusiness, SemesterBusiness>();

            container.RegisterType<ITeacherRepository, TeacherRepository>();
            container.RegisterType<ITeacherBusiness, TeacherBusiness>();

            container.RegisterType<IDesignationRepositoty, DesignationRepository>();
            container.RegisterType<IDesignationBusiness, DesignationBusiness>();

            container.RegisterType<IStudentResultRepository, StudentResultRepository>();
            container.RegisterType<IStudentResultBusiness, StudentResultBusiness>();


            container.RegisterType<ISeassonRepository, SeassonRepository>();
            container.RegisterType<ISeassonBusiness, SeassonBusiness>();




            container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(new HierarchicalLifetimeManager());
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<RolesAdminController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());
            container.RegisterType<UsersAdminController>(new InjectionConstructor());
        }
    }
}
