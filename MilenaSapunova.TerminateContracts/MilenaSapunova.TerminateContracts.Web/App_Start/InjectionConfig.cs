using MilenaSapunova.TerminateContracts.Auth;
using MilenaSapunova.TerminateContracts.Data.Models;
using MilenaSapunova.TerminateContracts.Data.Repositories;
using Ninject;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
using System.Data.Entity;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using System;
using MilenaSapunova.TerminateContracts.Services.Contracts;
using MilenaSapunova.TerminateContracts.Data.SaveContext;
using AutoMapper;
using MilenaSapunova.TerminateContracts.Services;
using MilenaSapunova.TerminateContracts.Auth.Contracts;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MilenaSapunova.TerminateContracts.Web.App_Start.InjectionConfig), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(MilenaSapunova.TerminateContracts.Web.App_Start.InjectionConfig), "Stop")]

namespace MilenaSapunova.TerminateContracts.Web.App_Start
{
    public static class InjectionConfig
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x =>
            {
                x.FromThisAssembly()
                 .SelectAllClasses()
                 .BindDefaultInterface();
            });

            kernel.Bind(x =>
            {
                x.FromAssemblyContaining(typeof(IDataService))
                .SelectAllAbstractClasses()
                .BindDefaultInterface();
            });

            kernel.Bind<ISignInService>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>());
            kernel.Bind<IUserManager>().ToMethod(_ => HttpContext.Current.GetOwinContext().Get<ApplicationUserManager>());
            kernel.Bind(typeof(DbContext), typeof(MsSqlDbContext)).To<MsSqlDbContext>().InRequestScope();
            kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<ITerminationNoticeService>().To<TerminationNoticeService>();
            kernel.Bind<ISaveContext>().To<SaveContext>();
            kernel.Bind<IMapper>().To<Mapper>();
        }
    }
}
