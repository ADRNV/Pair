using MvvmCross.Commands;
using Pair.App.Desktop.ViewModels.Common;
using Pair.App.Desktop.Views.MainPage;
using System.Windows;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainViewModel
    {
        private Page? _currentPage;

        private ICrudViewModel? _currentPageViewModel;

        public Page CurrentPage
        {
            get => _currentPage!;

            set
            {
                _currentPage = value;
                RaisePropertyChanged(nameof(CurrentPage));
            }
        }

        public ICrudViewModel CurrentPageViewModel
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

        private void ToTablePage(int obj)
        {
            switch (obj)
            {
                case 1:
                    this.CurrentPageViewModel = new PersonsViewModel(null);
                    this.CurrentPage = new MainPage();
                    break;
                case 2:
                    this.CurrentPageViewModel = new SocialLinksViewModel(null);
                    break;
            }
        }

        private void Add()
        {
            CurrentPageViewModel.AddCommand.ExecuteAsync();
        }
    }
}
