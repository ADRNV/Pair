namespace Pair.App.Desktop.ViewModels.Common
{
    public interface IEditViewModel<T> : IViewModel
    {
        T Item { get; set; }
    }
}
