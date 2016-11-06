using System.Windows;
using System.Windows.Controls;
using TestHarness.Entities;

namespace TestHarness.WPF.UC
{
    /// <summary>
    /// Interaction logic for AssemblyDetailView.xaml
    /// </summary>
    public partial class MethodDetailView : UserControl
    {
        public MethodDetailView()
        {
            InitializeComponent();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            var viewModel = (IMethodDetailViewModel) DataContext;
            viewModel.InvokeMethod();
        }
    }
}
