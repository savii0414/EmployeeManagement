using EmployeeManagement.Repositories.Interfaces;
using EmployeeManagement.Repositories.Implementations;
using EmployeeManagement.Services.Interfaces;           
using EmployeeManagement.Services.Implementations;
using System;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace EmployeeManagement.Web
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
            new Lazy<IUnityContainer>(() =>
            {
                var container = new UnityContainer();
                RegisterTypes(container);
                return container;
            });

        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// This is the method Global.asax.cs will call
        /// </summary>
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register all services and repositories
            RegisterTypes(container);

            // Set Unity as MVC Dependency Resolver
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        /// <summary>
        /// Registers types with Unity container
        /// </summary>
        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            container.RegisterType<ICacheService, CacheService>();
            container.RegisterType<IWorkingDayService, WorkingDayService>();
            container.RegisterType<IPublicHolidayRepository, PublicHolidayRepository>();
        }
    }
}