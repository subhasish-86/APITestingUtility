using TestHarness.Entities;
using TestHarness.ViewModel;

namespace TestHarness.WPF
{
    public class ViewModelLocator
    {
        //private static IUnityContainer _container;
        //public ViewModelLocator()
        //{
        //    _container = new UnityContainer();
        //    BootStrap();
        //}

        //private static void BootStrap()
        //{
            
        //    _container.RegisterInstance(typeof(IMainViewModel), new MainViewModel(),
        //        new ContainerControlledLifetimeManager());

        //}

        public IMainViewModel MainViewModel
        {
            get { return new MainViewModel(); }
        }
        
    }
}