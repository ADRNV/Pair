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

        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            IocKernel.Initialize(new ViewModelsModule(), new DataModule());

            base.OnStartup(e);

            ComposeObjects();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = IocKernel.Get<MainWindow>();
            Current.MainWindow.DataContext = IocKernel.Get<IMainViewModel>();
            Current.MainWindow.Show();
        }
    }
}
