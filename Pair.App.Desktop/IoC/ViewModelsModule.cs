using Ninject.Modules;
using Pair.App.Desktop.ViewModels;
using Pair.App.Desktop.ViewModels.Common;

namespace Pair.App.Desktop.IoC
{
    public class ViewModelsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMainViewModel>()
                .To<MainWindowViewModel>();
        }
    }
}
