using MvvmCross.Commands;
using Pair.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Pair.App.Desktop.ViewModels.Common
{
    public class EditViewModelBase<T> : ViewModelBase, IEditViewModel<T> where T : class, new()
    {
        protected readonly IRepository<T> _repository;

        protected T? _item = new();

        public EditViewModelBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public EditViewModelBase(T item)
        {
            _item = item;
        }

        public T Item
        {
            get => _item!;

            set
            {
                _item = value;
                RaisePropertyChanged(nameof(Item));
            }
        }

        public virtual IMvxCommand AddCommand => new MvxCommand(Add);

        public virtual IMvxCommand EditCommand => new MvxCommand(Edit);

        public virtual IMvxCommand CancelCommand => new MvxCommand(Cancel);

        protected virtual void Add()
        {
             _repository.Insert(Item);
        }

        protected virtual void Edit()
        {
            _repository.Update(Item);

            _item = new T();
        }

        protected virtual void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
