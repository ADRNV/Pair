using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.App.Desktop.ViewModels
{
    public class UsersViewModel : TableViewModelBase<User>
    {
        public UsersViewModel(IRepository<User> repository) : base(repository)
        {
        }
    }
}
