using MvvmCross.Commands;
using Pair.App.Desktop.ViewModels.Common;
using Pair.App.Desktop.Views.Auth;
using Pair.App.Desktop.Views.EditPage;
using Pair.App.Desktop.Views.Persons.MainPage;
using Pair.App.Desktop.Views.SocialLinks;
using Pair.App.Desktop.Views.SocialLinks.EditPage;
using Pair.Core.Models;
using Pair.Infrastructure.EF.Security.Entities.Configurations;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels
{
    ///TODO 1 Decomposite this <summary>
    ///TODO 2 Move Permissions properties to class
    public class MainWindowViewModel : ViewModelBase, IMainViewModel
    {
        private Page? _currentPage;

        private bool _canChange = false;

        private bool _canRead = false;

        private ICommonEditViewModel _currentPageViewModel;

        private ICommonEditViewModel _personEditViewModel;

        private ICommonEditViewModel _socialLinkEditViewModel;

        private readonly ITableViewModel<Person> _personsViewModel;

        private readonly ITableViewModel<SocialLink> _socialLinksViewModel;

        private readonly ITableViewModel<User> _usersViewModel;

        private readonly IEditViewModel<User> _userEditViewModel;

        private AuthViewModel _authViewModel;

        public MainWindowViewModel(IEditViewModel<Person> personEditViewModel, IEditViewModel<SocialLink> socialLinkEditViewModel,
            ITableViewModel<Person> personsViewModel, ITableViewModel<SocialLink> socialLinksViewModel, AuthViewModel authViewModel,
            IEditViewModel<User> userEditViewModel, ITableViewModel<User> usersViewModel)
        {
            _personEditViewModel = personEditViewModel;

            _socialLinkEditViewModel = socialLinkEditViewModel;

            _personsViewModel = personsViewModel;

            _socialLinksViewModel = socialLinksViewModel;

            _authViewModel = authViewModel;

            _usersViewModel = usersViewModel;

            _userEditViewModel = userEditViewModel;

            _authViewModel.WasSigned += ManageUi;

            CurrentPage = new AuthPage(_authViewModel);
        }

        private void ManageUi(Permissions permission)
        {
            switch (permission)
            {
                case Permissions.ReadAndWrite | Permissions.Manage:
                    CanChange = true;
                    CanRead = true;
                    break;
                case Permissions.Read:
                    CanRead = true;
                    break;
            }
        }

        public bool CanChange
        {
            get => _canChange;

            set
            {
                _canChange = value;
                RaisePropertyChanged(nameof(CanChange));
            }
        }

        public bool CanRead
        {
            get => _canRead;

            set
            {
                _canRead = value;
                RaisePropertyChanged(nameof(CanRead));
            }
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

        public IMvxCommand ExitFromUserCommand => new MvxCommand(ExitFromUser);

        public IMvxCommand ExitFromAppCommand => new MvxCommand(ExitFromApp);

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
                case 3:
                    this.CurrentPage = new UsersTablePage(_usersViewModel);
                    this.CurrentPageViewModel = _userEditViewModel;
                    break;

            }
        }

        private void Add()
        {
            if (this.CurrentPageViewModel is IEditViewModel<Person>)
            {
                this.CurrentPage = new EditPage(this.CurrentPageViewModel as IEditViewModel<Person>);
            }
            if (this.CurrentPageViewModel is IEditViewModel<User>)
            {
                this.CurrentPage = new UserEditPage(this.CurrentPageViewModel as IEditViewModel<User>);
            }
            else
            {
                this.CurrentPage = new SocialLinksEditPage(this.CurrentPageViewModel as IEditViewModel<SocialLink>);
            }
        }

        private async void Delete()
        {
            if (CurrentPageViewModel is IEditViewModel<Person>)
            {
                await this._personsViewModel.DeleteCommand.ExecuteAsync();
            }
            if(CurrentPageViewModel is IEditViewModel<User>)
            {
                await this._usersViewModel.DeleteCommand.ExecuteAsync();
            }
            else
            {
                await this._socialLinksViewModel.DeleteCommand.ExecuteAsync();
            }

        }

        private void ExitFromUser()
        {
            CanChange = false;
            CanRead = false;

            _authViewModel.Signed = false;

            CurrentPage = new AuthPage(_authViewModel);
        }

        private void ExitFromApp() => Environment.Exit(0);
    }
}
