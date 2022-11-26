using MvvmCross.Commands;
using Pair.Core.Repositories;
using System;

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

        public T Item
        {
            get => _item!;

            set
            {
                _item = value;
                RaisePropertyChanged(nameof(Item));
            }
        }

        public IMvxCommand AddCommand => new MvxCommand(Add);

        public IMvxCommand CancelCommand => new MvxCommand(Cancel);

        protected virtual void Add()
        {
            _repository.Insert(Item);
        }

        protected virtual void Cancel()
        {
            throw new NotImplementedException();
        }
    }
}
