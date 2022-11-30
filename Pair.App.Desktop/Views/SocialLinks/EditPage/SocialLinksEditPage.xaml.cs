using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
