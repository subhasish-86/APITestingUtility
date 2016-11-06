using Microsoft.Practices.Unity;
using TestHarness.Entities;
using TestHarness.ViewModel;

namespace TestHarness.WinForm
{
    public class ViewModelLocator
    {
        private static IUnityContainer _container;
        public ViewModelLocator()
        {
            _container = new UnityContainer();
            BootStrap();
        }

        private static void BootStrap()
        {
            
            _container.RegisterInstance(typeof(IMainViewModel), new MainViewModel(),
                new ContainerControlledLifetimeManager());

        }

        public IMainViewModel MainViewModel
        {
            get { return _container.Resolve<IMainViewModel>(); }
        }
        
    }
}