using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using System.Windows.Controls;

namespace Pair.App.Desktop.Views.Auth
{
    /// <summary>
    /// Логика взаимодействия для UserEditPage.xaml
    /// </summary>
    public partial class UserEditPage : Page
    {
        private readonly IEditViewModel<User> _userEditViewModel;
        public UserEditPage(IEditViewModel<User> userEditViewModel)
        {
            InitializeComponent();

            _userEditViewModel = userEditViewModel;

            this.DataContext = _userEditViewModel;
        }
    }
}
