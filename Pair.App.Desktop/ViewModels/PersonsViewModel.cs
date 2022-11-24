using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Pair.App.Desktop.ViewModels
{
    public class PersonsViewModel : CrudViewModelBase<Person>
    {
        public PersonsViewModel(IRepository<Person> repository) : base(repository)
        {
        }

        protected override Task Add()
        {
            throw new NotImplementedException();
        }

        protected override Task Delete()
        {
            throw new NotImplementedException();
        }

        protected override Task Edit()
        {
            throw new NotImplementedException();
        }

        protected override Task GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
