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

namespace Pair.App.Desktop.Views.Interests
{
    /// <summary>
    /// Логика взаимодействия для InterestsPage.xaml
    /// </summary>
    public partial class InterestsPage : Page
    {
        private readonly ITableViewModel<Interest> _interestsTableViewModel;

        public InterestsPage(ITableViewModel<Interest> interestsTableViewModel)
        {
            _interestsTableViewModel = interestsTableViewModel;

            InitializeComponent();

            this.DataContext = _interestsTableViewModel;

            _interestsTableViewModel.Load();
        }
    }
}
