using Ninject.Modules;
using Pair.App.Desktop.ViewModels;
using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Services;

namespace Pair.App.Desktop.IoC
{
    public class ViewModelsModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMainViewModel>()
                .To<MainWindowViewModel>();

            this.Bind<AdminService>()
                .ToSelf();

            //this.Bind<ICrudViewModel<SocialLink>>()
            //    .To<ICrudViewModel<SocialLink>>()
            //    .InTransientScope();

            this.Bind<IEditViewModel<Person>>()
                .To<PersonEditPageViewModel>()
                .InTransientScope();

            this.Bind<IEditViewModel<SocialLink>>()
                .To<SocialLinkEditViewModel>()
                .InTransientScope();

            this.Bind<IEditViewModel<Interest>>()
                .To<InterestEditViewModel>()
                .InTransientScope();

            this.Bind<ITableViewModel<Person>>()
                .To<PersonsViewModel>()
                .InTransientScope();

            this.Bind<ITableViewModel<SocialLink>>()
                .To<SocialLinksViewModel>()
                .InSingletonScope();

            this.Bind<ITableViewModel<Interest>>()
                .To<InterestsViewModel>()
                .InTransientScope();

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
