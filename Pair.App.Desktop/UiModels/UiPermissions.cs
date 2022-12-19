using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pair.App.Desktop.UiModels
{
    public class UiPermissions : INotifyPropertyChanged
    {
        private bool _canChange = false;

        private bool _canRead = false;

        private bool _canManage = false;

        public bool CanChange
        {
            get => _canChange;

            set
            {
                _canChange = value;
                OnPropertyChanged(nameof(CanChange));
            }
        }

        public bool CanRead
        {
            get => _canRead;

            set
            {
                _canRead = value;
                OnPropertyChanged(nameof(CanRead));
            }
        }

        public bool CanManage
        {
            get => _canManage;

            set
            {
                _canManage = value;
                OnPropertyChanged(nameof(CanManage));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
