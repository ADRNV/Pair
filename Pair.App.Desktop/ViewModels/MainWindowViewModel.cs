using MvvmCross.Commands;
using Pair.App.Desktop.ViewModels.Common;
using Pair.App.Desktop.Views.EditPage;
using Pair.App.Desktop.Views.Persons.MainPage;
using Pair.App.Desktop.Views.SocialLinks;
using Pair.Core.Models;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainViewModel
    {
        private Page? _currentPage;

        private IEditViewModel<Person> _currentPageViewModel;

        private readonly ITableViewModel<Person> _personsViewModel;

        private readonly ITableViewModel<SocialLink> _socialLinksViewModel;

        public MainWindowViewModel(IEditViewModel<Person> editViewModel,
            ITableViewModel<Person> personsViewModel, ITableViewModel<SocialLink> socialLinksViewModel)
        {
            _currentPageViewModel = editViewModel;

            _personsViewModel = personsViewModel;

            _socialLinksViewModel = socialLinksViewModel;
        }

        public Page CurrentPage
        {
            get => _currentPage!;

            set
            {
                _currentPage = value;
                RaisePropertyChanged(nameof(CurrentPage));
            }
        }

        public IViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel!;

            set
            {
                _currentPageViewModel = value as IEditViewModel<Person>;

                RaisePropertyChanged(nameof(CurrentPageViewModel));
            }
        }

        public IMvxCommand<int> ToTablePageCommand => new MvxCommand<int>((t) => ToTablePage(t));

        public IMvxCommand AddCommand => new MvxCommand(Add);

        public IMvxCommand DeleteCommand => new MvxCommand(Delete);

        private void ToTablePage(int obj)
        {
            switch (obj)
            {
                case 1:
                    this.CurrentPage = new PersonsPage(_personsViewModel);
                    break;
                case 2:
                    this.CurrentPage = new SocialLinksPage(_socialLinksViewModel);
                    break;
            }
        }

        private void Add()
        {
            this.CurrentPage = new EditPage(this.CurrentPageViewModel as IEditViewModel<Person>);
        }

        private async void Delete()
        {
            await this._personsViewModel.DeleteCommand.ExecuteAsync();
        }
    }
}
