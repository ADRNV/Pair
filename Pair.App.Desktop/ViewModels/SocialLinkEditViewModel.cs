using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System.Threading.Tasks;

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

        protected async override Task Add()
        {
            await _repository.Insert(Item);
        }
    }
}
