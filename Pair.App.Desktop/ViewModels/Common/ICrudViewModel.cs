using MvvmCross.Commands;

namespace Pair.App.Desktop.ViewModels.Common
{
    public interface ICrudViewModel
    {
        IMvxAsyncCommand GetAllCommand { get; }

        IMvxAsyncCommand AddCommand { get; }

        IMvxAsyncCommand EditCommand { get; }

        IMvxAsyncCommand DeleteCommand { get; }
    }
}
