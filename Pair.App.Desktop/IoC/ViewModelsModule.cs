using MvvmCross.Binding.BindingContext;
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

            //this.Bind<ICrudViewModel<SocialLink>>()
            //    .To<ICrudViewModel<SocialLink>>()
            //    .InTransientScope();

            this.Bind<IEditViewModel<Person>>()
                .To<PersonEditPageViewModel>()
                .InTransientScope();

            this.Bind<IEditViewModel<SocialLink>>()
                .To<SocialLinkEditViewModel>()
                .InTransientScope();

            this.Bind<ITableViewModel<Person>>()
                .To<PersonsViewModel>()
                .InTransientScope();

            this.Bind<ITableViewModel<SocialLink>>()
                .To<SocialLinksViewModel>()
                .InSingletonScope();

            this.Bind<AuthViewModel>()
                .ToSelf()
                .InTransientScope();

            this.Bind<ITableViewModel<User>>()
                .To<UsersViewModel>()
                .InTransientScope();

            this.Bind<IEditViewModel<User>>()
                .To<UserEditViewModel>()
                .InTransientScope();
        }
    }
}
