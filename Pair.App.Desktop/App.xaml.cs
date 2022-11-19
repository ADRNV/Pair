using Ninject;
using Pair.App.Desktop.IoC;
using Pair.App.Desktop.ViewModels.Common;
using System.Windows;

namespace Pair.App.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IKernel _kernel;

        public App()
        {
            _kernel = new StandardKernel(new ViewModelsModule());
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var vm = _kernel.Get<IMainViewModel>();

            MainWindow = new MainWindow(vm);

            base.OnStartup(e);
        }
    }
}
