using MvvmCross.Commands;
using Pair.App.Desktop.ViewModels.Common;
using Pair.App.Desktop.Views.MainPage;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private Page _currentPage;

        public Page CurrentPage
        {
            get => _currentPage;

            set
            {
                _currentPage = value;
                RaisePropertyChanged(nameof(CurrentPage));
            }
        }

        public IMvxCommand ToTablePageCommand => new MvxCommand(ToTablePage);
        private void ToTablePage()
        {
            CurrentPage = new MainPage();
        }
    }
}
