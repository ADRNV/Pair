using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;

namespace Pair.App.Desktop.ViewModels
{
    public class SocialLinksViewModel : TableViewModelBase<SocialLink>
    {
        public SocialLinksViewModel(IRepository<SocialLink> repository) : base(repository)
        {

        }
    }
}
