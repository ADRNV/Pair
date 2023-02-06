using Pair.App.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pair.App.Desktop.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для ImageDataTemplate.xaml
    /// </summary>
    public partial class ImageDataTemplate : UserControl
    {
        private ImageCellViewModel _imageCellViewModel;

        public ImageDataTemplate()
        {
            _imageCellViewModel = new ImageCellViewModel();

            InitializeComponent();

            this.DataContext = _imageCellViewModel;
        }
    }
}
