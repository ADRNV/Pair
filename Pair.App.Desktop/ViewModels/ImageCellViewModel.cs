using MvvmCross.Commands;
using Pair.App.Desktop.ViewModels.Common;
using System.Windows.Controls;

namespace Pair.App.Desktop.ViewModels
{
    public class ImageCellViewModel : ViewModelBase
    {
        private string _imageUri;

        public string ImageUri
        {
            get => _imageUri;

            set
            {
                _imageUri = value;
                RaisePropertyChanged(nameof(ImageUri)); 
            }
        }

        public IMvxCommand ViewLargeCommand => new MvxCommand(ViewLarge);

        private void ViewLarge()
        {

        }

    }
}
