using System.Windows;
using System.Windows.Controls;
using TestHarness.Entities;

namespace TestHarness.WPF.UC
{
    /// <summary>
    /// Interaction logic for AssemblyDetailView.xaml
    /// </summary>
    public partial class ConstructorDetailView : UserControl
    {
        public ConstructorDetailView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (IConstructorDetailViewModel) DataContext;
            viewModel.CreateInstance();
        }
    }
}
