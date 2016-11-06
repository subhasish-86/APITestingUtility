using TestHarness.Entities;

namespace TestHarness.ViewModel
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private IAssemblyDetailViewModel _assemblyDetailViewModel;
        private IConstructorDetailViewModel _constructorDetailViewModel;
        private IMethodDetailViewModel _methodDetailViewModel;

        public MainViewModel()
        {
            AssemblyDetailViewModel = new AssemblyDetailViewModel();
            ConstructorDetailViewModel = new ConstructorDetailViewModel();
            MethodDetailViewModel = new MethodDetailViewModel();
            AssemblyDetailViewModel.SelectedTypeUpdated += AssemblyDetailViewModelSelectedTypeUpdated;
            ConstructorDetailViewModel.InstanceUpdated += ConstructorDetailViewModel_InstanceUpdated;
        }

        private void ConstructorDetailViewModel_InstanceUpdated(object sender, System.EventArgs e)
        {
            AssemblyDetailViewModel.CreatedInstance = ((IConstructorDetailViewModel) sender).Instance;
            MethodDetailViewModel.Instance = ((IConstructorDetailViewModel) sender).Instance;
        }

        private void AssemblyDetailViewModelSelectedTypeUpdated(object sender, System.EventArgs e)
        {
            ConstructorDetailViewModel.SelectedType = AssemblyDetailViewModel.SelectedType;
            MethodDetailViewModel.SelectedType = AssemblyDetailViewModel.SelectedType;
        }

        public IAssemblyDetailViewModel AssemblyDetailViewModel
        {
            get { return _assemblyDetailViewModel; }
            set
            {
                _assemblyDetailViewModel = value;
                OnPropertyChanged("AssemblyDetailViewModel");
            }
        }


        public IMethodDetailViewModel MethodDetailViewModel
        {
            get { return _methodDetailViewModel; }
            set
            {
                _methodDetailViewModel = value;
                OnPropertyChanged("MethodDetailViewModel");
            }
        }

        public IConstructorDetailViewModel ConstructorDetailViewModel
        {
            get { return _constructorDetailViewModel; }
            private set
            {
                _constructorDetailViewModel = value;
                OnPropertyChanged("ConstructorDetailViewModel");
            }
        }
    }
}
