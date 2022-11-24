using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System.Threading.Tasks;

namespace Pair.App.Desktop.ViewModels
{
    public class SocialLinksViewModel : CrudViewModelBase<SocialLink>
    {
        public SocialLinksViewModel(IRepository<SocialLink> repository) : base(repository)
        {
        }

        protected override Task Add()
        {
            throw new System.NotImplementedException();
        }

        protected override Task Delete()
        {
            throw new System.NotImplementedException();
        }

        protected override Task Edit()
        {
            throw new System.NotImplementedException();
        }

        protected override Task GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}
