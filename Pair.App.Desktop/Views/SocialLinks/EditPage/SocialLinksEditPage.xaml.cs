using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using System.Windows.Controls;

namespace Pair.App.Desktop.Views.SocialLinks.EditPage
{
    /// <summary>
    /// Логика взаимодействия для SocialLinksEditPage.xaml
    /// </summary>
    public partial class SocialLinksEditPage : Page
    {
        private readonly IEditViewModel<SocialLink> _socialLinkEditViewModel;

        public SocialLinksEditPage(IEditViewModel<SocialLink> socialLinkViewModel)
        {
            _socialLinkEditViewModel = socialLinkViewModel;

            InitializeComponent();

            this.DataContext = _socialLinkEditViewModel;
        }
    }
}
