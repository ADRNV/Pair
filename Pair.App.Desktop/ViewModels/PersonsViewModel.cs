using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Pair.App.Desktop.ViewModels
{
    public class PersonsViewModel : TableViewModelBase<Person>
    {
        public PersonsViewModel(IPersonsRepository repository) : base(repository)
        {

        }

        protected override async Task Search(string obj)
        {
            var items = await _repository.Find(obj, obj);

            Items = new ObservableCollection<Person>(items);
        }
    }
}