using Pair.App.Desktop.ViewModels.Common;
using System.Windows.Controls;

namespace Pair.App.Desktop.Views.MainPage
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, IMvvmPage
    {
        private ViewModelBase _viewmodel;
        public MainPage()
        {
            InitializeComponent();
        }

        public MainPage(ViewModelBase viewModelBase)
        {
            _viewmodel = viewModelBase;

            InitializeComponent();

            DataContext = viewModelBase;
        }

        public ViewModelBase ViewModel => _viewmodel;
    }
}
