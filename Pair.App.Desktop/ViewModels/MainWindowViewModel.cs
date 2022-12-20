using MvvmCross.Commands;
using Pair.App.Desktop.UiModels;
using Pair.App.Desktop.ViewModels.Common;
using Pair.App.Desktop.Views.Auth;
using Pair.App.Desktop.Views.EditPage;
using Pair.App.Desktop.Views.Persons.MainPage;
using Pair.App.Desktop.Views.SocialLinks;
using Pair.App.Desktop.Views.SocialLinks.EditPage;
using Pair.Core.Models;
using Pair.Infrastructure.EF.Security.Entities.Configurations;
using Pair.Services;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels
{
    ///TODO 1 Decomposite this <summary>
    public class MainWindowViewModel : ViewModelBase, IMainViewModel
    {
        #region Fields

        private Page? _currentPage;

        private readonly AdminService _adminService;

        private UiPermissions _uiPermissions = new UiPermissions();
        
        private ICommonEditViewModel _currentPageViewModel;

        private ICommonEditViewModel _personEditViewModel;

        private ICommonEditViewModel _socialLinkEditViewModel;

        private readonly ITableViewModel<Person> _personsViewModel;

        private readonly ITableViewModel<SocialLink> _socialLinksViewModel;

        private readonly ITableViewModel<User> _usersViewModel;

        private readonly IEditViewModel<User> _userEditViewModel;

        private AuthViewModel _authViewModel;

        private string _searchString;
        #endregion
        
        public MainWindowViewModel(IEditViewModel<Person> personEditViewModel, IEditViewModel<SocialLink> socialLinkEditViewModel,
            ITableViewModel<Person> personsViewModel, ITableViewModel<SocialLink> socialLinksViewModel, AuthViewModel authViewModel,
            IEditViewModel<User> userEditViewModel, ITableViewModel<User> usersViewModel, AdminService adminService)
        {
            _personEditViewModel = personEditViewModel;

            _socialLinkEditViewModel = socialLinkEditViewModel;

            _personsViewModel = personsViewModel;

            _socialLinksViewModel = socialLinksViewModel;

            _authViewModel = authViewModel;

            _usersViewModel = usersViewModel;

            _userEditViewModel = userEditViewModel;

            _adminService = adminService;

            _authViewModel.WasSigned += ManageUi;

            CurrentPage = new AuthPage(_authViewModel);
        }

        public UiPermissions UiPermissions
        {
            get => _uiPermissions;

            set
            {
                _uiPermissions = value;
                RaisePropertyChanged(nameof(UiPermissions));
            }
        }

        private void ManageUi(Permissions permission)
        {
            //if (_adminService.GetCurrentUserPermission())
            //{
            //    UiPermissions.CanManage = true;
            //    UiPermissions.CanChange = true;
            //    UiPermissions.CanRead = true;
            //    return;
            //}
            switch (permission)
            {
                case Permissions.ReadAndWrite | Permissions.Manage:
                    UiPermissions.CanChange = true;
                    UiPermissions.CanRead = true;
                    UiPermissions.CanManage = true;
                    break;
                case Permissions.Read:
                    UiPermissions.CanRead = true;
                    break;
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

        public string SearchString
        {
            get => _searchString;

            set
            {
                _searchString = value;
                RaisePropertyChanged(nameof(SearchString));
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

        public IMvxCommand EditCommand => new MvxCommand(Edit);

        public IMvxCommand DeleteCommand => new MvxCommand(Delete);

        public IMvxAsyncCommand<string> SearchCommand => new MvxAsyncCommand<string>(Search);

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
            if (this.CurrentPageViewModel is IEditViewModel<SocialLink>)
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
            if (CurrentPageViewModel is IEditViewModel<User>)
            {
                await this._usersViewModel.DeleteCommand.ExecuteAsync();
            }
            else
            {
                await this._socialLinksViewModel.DeleteCommand.ExecuteAsync();
            }

        }

        private async void Edit()
        {
            if (CurrentPage is PersonsPage)
            {
                var editVm = (CurrentPageViewModel as IEditViewModel<Person>);

                editVm.Item = _personsViewModel.SelectedItem;

                CurrentPage = new EditPage(editVm);
            }
            if (CurrentPage is SocialLinksPage)
            {
                var editVm = (CurrentPageViewModel as IEditViewModel<SocialLink>);

                editVm.Item = _socialLinksViewModel.SelectedItem;

                CurrentPage = new SocialLinksEditPage(editVm);
            }
            if (CurrentPage is UsersTablePage)
            {
                var editVm = (CurrentPageViewModel as IEditViewModel<User>);

                editVm.Item = _usersViewModel.SelectedItem;

                CurrentPage = new UserEditPage(editVm);
            }
        }

        private async Task Search(string obj)
        {
            if (CurrentPage is PersonsPage)
            {
                await _personsViewModel.SearchCommand.ExecuteAsync(obj); 
            }
            if (CurrentPage is SocialLinksPage)
            {
                await _socialLinksViewModel.SearchCommand.ExecuteAsync(obj);
            }
        }

        private void ExitFromUser()
        {
            UiPermissions.CanChange = false;
            UiPermissions.CanRead = false;

            _authViewModel.Signed = false;
            _authViewModel.Login = String.Empty;
            _authViewModel.Password = String.Empty;
            CurrentPage = new AuthPage(_authViewModel);
        }

        private void ExitFromApp() => Environment.Exit(0);
    }
}
