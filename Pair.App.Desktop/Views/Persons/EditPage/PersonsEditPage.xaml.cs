using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using System.Windows.Controls;

namespace Pair.App.Desktop.Views.EditPage
{
    /// <summary>
    /// Логика взаимодействия для EditPage.xaml
    /// </summary>
    public partial class EditPage : Page
    {
        public IEditViewModel<Person> PersonsViewModel { get; set; }

        public EditPage(IEditViewModel<Person> personsViewModel)
        {
            InitializeComponent();

            this.PersonsViewModel = personsViewModel;

            this.DataContext = PersonsViewModel;
        }
    }
}
