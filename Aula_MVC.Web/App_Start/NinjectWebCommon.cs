using System.Web.Mvc;
using Aula_MVC.Domain.Repository;
using Aula_MVC.Data.NHibernate;
using Aula_MVC.Domain.Service;
using Aula_MVC.Repository.NH.Impl;
using Aula_MVC.Web.Helpers.Mappers;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Aula_MVC.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Aula_MVC.Web.App_Start.NinjectWebCommon), "Stop")]


namespace Aula_MVC.Web.App_Start
{

    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon
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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);

            //Injeta as referencias nos contrutores dos controlles
            //IOC mvc
            DependencyResolver.SetResolver(new NinjectDependency.NinjectDependencyResolver(kernel));

            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            kernel.Bind<ICategoriaRepository>().To<CategoriaRepository>();
            kernel.Bind<ICategoriaMapper>().To<CategoriaMapper>();


            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IProdutoMapper>().To<ProdutoMapper>();

            kernel.Bind<IVendaRepository>().To<VendaRepository>();
            kernel.Bind<IVendaMapper>().To<VendaMapper>();
            kernel.Bind<IVendaService>().To<VendaService>();

        }
    }
}



















