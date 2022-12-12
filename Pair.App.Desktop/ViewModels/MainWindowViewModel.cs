using MvvmCross.Commands;
using Pair.App.Desktop.ViewModels.Common;
using Pair.App.Desktop.Views.EditPage;
using Pair.App.Desktop.Views.Persons.MainPage;
using Pair.App.Desktop.Views.SocialLinks;
using Pair.App.Desktop.Views.SocialLinks.EditPage;
using Pair.Core.Models;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainViewModel
    {
        private Page? _currentPage;

        private ICommonEditViewModel _currentPageViewModel;

        private ICommonEditViewModel _personEditViewModel;

        private ICommonEditViewModel _socialLinkEditViewModel;

        private readonly ITableViewModel<Person> _personsViewModel;

        private readonly ITableViewModel<SocialLink> _socialLinksViewModel;

        public MainWindowViewModel(IEditViewModel<Person> personEditViewModel, IEditViewModel<SocialLink> socialLinkEditViewModel,
            ITableViewModel<Person> personsViewModel, ITableViewModel<SocialLink> socialLinksViewModel)
        {
            _personEditViewModel = personEditViewModel;

            _socialLinkEditViewModel = socialLinkEditViewModel;

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

        public ICommonEditViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel!;

            set
            {
                _currentPageViewModel = value;

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
                    this.CurrentPageViewModel = _personEditViewModel;
                    break;
                case 2:
                    this.CurrentPage = new SocialLinksPage(_socialLinksViewModel);
                    this.CurrentPageViewModel = _socialLinkEditViewModel;
                    break;
            }
        }

        private void Add()
        {
            if (this.CurrentPageViewModel is IEditViewModel<Person>)
            {
                this.CurrentPage = new EditPage(this.CurrentPageViewModel as IEditViewModel<Person>);
            }
            else
            {
                this.CurrentPage = new SocialLinksEditPage(this.CurrentPageViewModel as IEditViewModel<SocialLink>);
            }
        }

        private async void Delete()
        {   
            if(CurrentPageViewModel is IEditViewModel<Person>)
            {
                await this._personsViewModel.DeleteCommand.ExecuteAsync();
            }
            else
            {
                await this._socialLinksViewModel.DeleteCommand.ExecuteAsync();
            }
            
        }

    }
}
