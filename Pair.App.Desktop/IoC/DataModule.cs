using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

            this.Bind<IRepository<Person>>()
                .To<PersonsRepository>()
                .InSingletonScope()
                .WithConstructorArgument("configuration", configuration);

            this.Bind<IRepository<SocialLink>>()
                .To<SocialLinksRepository>()
                .InSingletonScope()
                .WithConstructorArgument("configuration", configuration);

            //Replace with AddEntityFrameWorkStorage() extension
            this.Bind<AuthContext>()
                .ToSelf()
                .WithConstructorArgument("options", configuration.GetConnectionString("AuthDbConnection"));

            this.Bind<IAuthRepository<User>>()
                .To<UsersRepository>();
        }
    }
}
