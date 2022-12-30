using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;

namespace Pair.App.Desktop.ViewModels
{
    public class UsersViewModel : TableViewModelBase<User>
    {
        public UsersViewModel(IRepository<User> repository) : base(repository)
        {
        }
    }
}
