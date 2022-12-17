using Pair.App.Desktop.ViewModels;
using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
