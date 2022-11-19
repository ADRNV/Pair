using Pair.App.Desktop.ViewModels;
using Pair.App.Desktop.ViewModels.Common;
using System.Windows;
namespace Pair.App.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModelBase _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();

            this.DataContext = _viewModel;
        }

        public MainWindow(ViewModelBase viewModel) : this()
        {
            _viewModel = new MainWindowViewModel();

            DataContext = _viewModel;
        }
    }
}
