using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using System.Windows.Controls;

namespace Pair.App.Desktop.Views.Auth
{
    /// <summary>
    /// Логика взаимодействия для UsersTablePage.xaml
    /// </summary>
    public partial class UsersTablePage : Page
    {
        private readonly ITableViewModel<User> _usersViewModel;
        public UsersTablePage(ITableViewModel<User> usersViewModel)
        {
            _usersViewModel = usersViewModel;

            InitializeComponent();

            this.DataContext = _usersViewModel;

            _usersViewModel.Load();
        }
    }
}
