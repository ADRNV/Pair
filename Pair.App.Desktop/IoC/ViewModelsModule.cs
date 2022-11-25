using Ninject.Modules;
using Pair.App.Desktop.ViewModels;
using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;

namespace Pair.App.Desktop.IoC
{
    public class ViewModelsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMainViewModel>()
                .To<MainWindowViewModel>();

            this.Bind<CrudViewModelBase<Person>>()
                .To<PersonsViewModel>();

            this.Bind<CrudViewModelBase<SocialLink>>()
                .To<SocialLinksViewModel>();
        }
    }
}
