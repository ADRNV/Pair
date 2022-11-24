using MvvmCross.Commands;
using Pair.Core.Repositories;
using System.Threading.Tasks;

namespace Pair.App.Desktop.ViewModels.Common
{
    public abstract class CrudViewModelBase<T> : ViewModelBase, ICrudViewModel
    {
        protected readonly IRepository<T> _repository;

        public CrudViewModelBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public IMvxAsyncCommand GetAllCommand => new MvxAsyncCommand(GetAll);

        public IMvxAsyncCommand AddCommand => new MvxAsyncCommand(Add);

        public IMvxAsyncCommand EditCommand => new MvxAsyncCommand(Edit);

        public IMvxAsyncCommand DeleteCommand => new MvxAsyncCommand(Delete);

        protected abstract Task GetAll();

        protected abstract Task Add();

        protected abstract Task Edit();

        protected abstract Task Delete();
    }
}
