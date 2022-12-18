using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;

namespace Pair.App.Desktop.ViewModels
{
    public class PersonsViewModel : TableViewModelBase<Person>
    {
        public PersonsViewModel(IPersonsRepository repository) : base(repository)
        {

        }
    }
}