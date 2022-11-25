using Microsoft.Extensions.Configuration;
using Ninject.Modules;
using Pair.Core.Repositories;
using Pair.Infrastructure.DapperORM;

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
        }
    }
}
