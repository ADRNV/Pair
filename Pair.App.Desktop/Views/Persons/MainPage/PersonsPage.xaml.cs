using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using System.Windows.Controls;

namespace Pair.App.Desktop.Views.Persons.MainPage
{
    /// <summary>
    /// Логика взаимодействия для PersonsPage.xaml
    /// </summary>
    public partial class PersonsPage : Page
    {
        private readonly ITableViewModel<Person> _personsViewModel;

        public PersonsPage(ITableViewModel<Person> tableViewModel)
        {
            _personsViewModel = tableViewModel;

            InitializeComponent();

            DataContext = _personsViewModel;

            _personsViewModel.Load();
        }
    }
}
