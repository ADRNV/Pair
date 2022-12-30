using Pair.App.Desktop.ViewModels;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
