using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace Pair.App.Desktop.ViewModels
{
    public class InterestEditViewModel : EditViewModelBase<Interest>
    {
        public InterestEditViewModel(IInterestsRepository repository) : base(repository)
        {
        }

        public string InterestName
        {
            get => _item!.InterestName;

            set
            {
                _item.InterestName = value;
                RaisePropertyChanged(nameof(InterestName));
            }
        }
    }
}
