using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ninject.Modules;
using Pair.Core.Models;
using Pair.Core.Repositories;
using Pair.Infrastructure.DapperORM;
using Pair.Infrastructure.EF;
using Pair.Infrastructure.EF.Security;

namespace Pair.App.Desktop.IoC
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile(@"AppSetting.json", false)
                .Build();

            this.Bind<IPersonsRepository>()
                .To<PersonsRepository>()
                .InSingletonScope()
                .WithConstructorArgument("configuration", configuration);

            this.Bind<ISocialLinksRepository>()
                .To<SocialLinksRepository>()
                .InSingletonScope()
                .WithConstructorArgument("configuration", configuration);

            this.Bind<IInterestsRepository>()
                .To<InterestsRepository>()
                .WithConstructorArgument("configuration", configuration);
            //Replace with AddEntityFrameWorkStorage() extension

            this.Bind<IInterestsPersonsRepository>()
                .To<InterestsPersonsRepository>()
                .WithConstructorArgument("configuration", configuration);

            var connectionString = configuration.GetConnectionString("AuthDbConnection");

            this.Bind<AuthContext>()
                .ToSelf()
                .WithConstructorArgument("connectionString", connectionString);

            this.Bind<IAuthRepository<User>>()
                .To<UsersRepository>();

            this.Bind<IRepository<User>>()
                .To<UsersRepository>();
        }
    }
}
