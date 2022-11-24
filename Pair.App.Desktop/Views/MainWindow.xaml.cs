using Pair.App.Desktop.ViewModels.Common;
using System.Windows;
namespace Pair.App.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IMainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            DataContext = ViewModel;
        }
    }
}
