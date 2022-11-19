using Pair.App.Desktop.ViewModels.Common;
using System.Windows;
namespace Pair.App.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IMainViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IMainViewModel viewModel)
        {
            _viewModel = viewModel;

            InitializeComponent();

            DataContext = _viewModel;
        }
    }
}
