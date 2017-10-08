using Ninject;


namespace Aula_MVC.Web.NinjectDependency
{
    public class NinjectDependencyResolver : NinjectDependencyScope, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(IKernel kernel) : base(kernel)
        {
            _kernel = kernel;
        }
    }
}
