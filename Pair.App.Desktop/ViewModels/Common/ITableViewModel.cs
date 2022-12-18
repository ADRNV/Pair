using MvvmCross.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pair.App.Desktop.ViewModels.Common
{
    public interface ITableViewModel<T>
    {
        Task<IEnumerable<T>> Load();

        public T SelectedItem { get; set; }
        IMvxAsyncCommand DeleteCommand { get; }
    }
}
