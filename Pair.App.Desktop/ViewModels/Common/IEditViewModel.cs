namespace Pair.App.Desktop.ViewModels.Common
{
    public interface IEditViewModel<T> : IViewModel, ICommonEditViewModel
    {
        T Item { get; set; }
    }
}
