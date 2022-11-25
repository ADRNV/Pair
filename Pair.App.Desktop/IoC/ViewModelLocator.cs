using Ninject;
using Pair.App.Desktop.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pair.App.Desktop.IoC
{
    class ViewModelLocator
    {
        public ICrudViewModel ViewModel
        {
            get { return IocKernel.Get<ICrudViewModel>(); }
        }
    }
}
