using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using System.Windows.Controls;

namespace Pair.App.Desktop.Views.SocialLinks
{
    /// <summary>
    /// Логика взаимодействия для SocialLinksPage.xaml
    /// </summary>
    public partial class SocialLinksPage : Page
    {
        private readonly ITableViewModel<SocialLink> _socialLinksViewModel;

        public SocialLinksPage(ITableViewModel<SocialLink> socialLinksViewModel)
        {
            _socialLinksViewModel = socialLinksViewModel;

            _socialLinksViewModel.Load();

            InitializeComponent();

            this.DataContext = _socialLinksViewModel;
        }
    }
}
