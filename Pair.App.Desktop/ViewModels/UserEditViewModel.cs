using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using Pair.Infrastructure.EF.Security.Entities.Configurations;

namespace Pair.App.Desktop.ViewModels
{
    public class UserEditViewModel : EditViewModelBase<User>
    {
        public UserEditViewModel(IRepository<User> repository) : base(repository)
        {

        }

        public string Login
        {
            get => _item.Login;

            set
            {
                _item.Login = value;
                RaisePropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _item.Password;

            set
            {
                _item.Password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public Permissions Permissions
        {
            get => _item.Permissions;

            set
            {
                _item.Permissions = value;
                RaisePropertyChanged(nameof(Permissions));
            }
        }
    }
}
