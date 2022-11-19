using MvvmCross.Commands;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels.Common
{
    public interface IMainViewModel
    {
        IMvxCommand ToTablePageCommand { get; }

        Page CurrentPage { get; set; }
    }
}
