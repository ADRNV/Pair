using Pair.App.Desktop.Views.MainPage;
using System.Windows;

namespace Pair.App.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            pagger.Content = new MainPage();
        }
    }
}
