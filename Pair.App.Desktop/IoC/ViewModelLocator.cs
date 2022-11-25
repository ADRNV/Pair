using Pair.App.Desktop.ViewModels.Common;

namespace Pair.App.Desktop.IoC
{
    class ViewModelLocator
    {
        public ICrudViewModel ViewModel
        {
            get { return IocKernel.Get<ICrudViewModel>(); }
        }
    }
}
