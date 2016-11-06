using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace TestHarness.WPF.UC
{
    /// <summary>
    /// Interaction logic for AssemblyDetailView.xaml
    /// </summary>
    public partial class AssemblyDetailView : UserControl
    {
        public AssemblyDetailView()
        {
            InitializeComponent();
        }

        private void LoadAssemblyButton_OnClick(object sender, RoutedEventArgs e)
        {
            var fileOpenDialoge = new OpenFileDialog();
            var isFileSelected = fileOpenDialoge.ShowDialog();
            if (isFileSelected != null && isFileSelected.Value)
            {
                AssemblyFileTextBox.Text = fileOpenDialoge.FileName;
            }
        }

        private void LoadXmlHelpFileButton_OnClick(object sender, RoutedEventArgs e)
        {
            var fileOpenDialoge = new OpenFileDialog();
            var isFileSelected = fileOpenDialoge.ShowDialog();
            if (isFileSelected != null && isFileSelected.Value)
            {
                XmlHelpFileTextBox.Text = fileOpenDialoge.FileName;
            }
        }
    }
}
