using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;

namespace Pair.App.Desktop.ViewModels
{
    internal class InterestsViewModel : TableViewModelBase<Interest>
    {
        public InterestsViewModel(IInterestsRepository repository) : base(repository)
        {
        }
    }
}
