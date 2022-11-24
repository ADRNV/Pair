using Ninject;
using Pair.App.Desktop.IoC;
using Pair.App.Desktop.ViewModels.Common;
using System;
using System.ComponentModel;
using System.Windows;

namespace Pair.App.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel _kernel;

        public App()
        {
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ConfigureContainer();
            ComposeObjects();
        }

        private void ComposeObjects()
        {
            Current.MainWindow = _kernel.Get<MainWindow>();
            Current.MainWindow.DataContext = _kernel.Get<IMainViewModel>();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            _kernel = new StandardKernel(new ViewModelsModule());
        }
    }
}
