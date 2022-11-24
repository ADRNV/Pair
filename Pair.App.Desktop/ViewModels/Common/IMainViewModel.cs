using MvvmCross.Commands;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels.Common
{
    public interface IMainViewModel
    {
        Page CurrentPage { get; set; }
    }
}
