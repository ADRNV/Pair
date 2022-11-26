using Pair.App.Desktop.ViewModels.Common;

namespace Pair.App.Desktop.IoC
{
    class ViewModelLocator
    {
        public ViewModelBase ViewModel
        {
            get { return IocKernel.Get<ViewModelBase>(); }
        }
    }
}
