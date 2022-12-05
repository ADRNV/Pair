using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Pair.App.Desktop.ViewModels
{
    public class SocialLinkEditViewModel : EditViewModelBase<SocialLink>
    {
        public SocialLinkEditViewModel(IRepository<SocialLink> repository) : base(repository)
        {
        }

        public string Name
        {
            get => _item.Name;

            set
            {
                _item.Name = value;
                RaisePropertyChanged(nameof(Name));
            }
        }

        public string Link
        {
            get => _item.Link;

            set
            {
                _item.Link = value;
                RaisePropertyChanged(nameof(Link));
            }
        }

        public int PersonId
        {
            get => _item.PersonId;

            set
            {
                _item.PersonId = value;
                RaisePropertyChanged(nameof(PersonId));
            }
        }
    }
}
