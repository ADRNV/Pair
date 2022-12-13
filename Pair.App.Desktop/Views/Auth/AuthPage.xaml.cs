using Pair.App.Desktop.ViewModels;
using System.Windows.Controls;

namespace Pair.App.Desktop.Views.Auth
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private AuthViewModel _authViewModel;

        public AuthPage(AuthViewModel authViewModel)
        {
            _authViewModel = authViewModel;

            InitializeComponent();

            this.DataContext = _authViewModel;
        }
    }
}
