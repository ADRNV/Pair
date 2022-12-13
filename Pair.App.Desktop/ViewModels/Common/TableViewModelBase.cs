using MvvmCross.Commands;
using Pair.Core.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Pair.App.Desktop.ViewModels.Common
{
    public abstract class TableViewModelBase<T> : ViewModelBase, ITableViewModel<T>
    {
        protected readonly IRepository<T> _repository;

        private ObservableCollection<T>? _items;

        private T? _selectedItem;

        public ObservableCollection<T> Items
        {
            get => _items!;

            set
            {
                _items = value;
                RaisePropertyChanged(nameof(Items));
            }
        }

        public T SelectedItem
        {
            get => _selectedItem;

            set
            {
                _selectedItem = value;
                RaisePropertyChanged(nameof(SelectedItem));
            }
        }

        public TableViewModelBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual IMvxAsyncCommand DeleteCommand => new MvxAsyncCommand(Delete, CanDelete);

        protected async virtual Task Delete()
        {
            await _repository.Delete(SelectedItem);
        }

        protected virtual bool CanDelete() => _selectedItem is not null;

        public virtual async Task<IEnumerable<T>> Load()
        {
            var items = await _repository.Get();

            Items = new ObservableCollection<T>(items);

            return Items;
        }
    }
}
