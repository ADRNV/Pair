using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;

namespace Pair.App.Desktop.ViewModels
{
    public class PersonEditPageViewModel : EditViewModelBase<Person>
    {
        public PersonEditPageViewModel(IPersonsRepository repository) : base(repository)
        {

        }

        public string PersonName
        {
            get => _item!.Name;

            set
            {
                _item.Name = value;
                RaisePropertyChanged(nameof(PersonName));
            }
        }

        public int PersonAge
        {
            get => _item!.Age;

            set
            {
                _item!.Age = value;
                RaisePropertyChanged(nameof(PersonBio));
            }
        }

        public string PersonBio
        {
            get => _item!.Bio;

            set
            {
                _item!.Bio = value;
                RaisePropertyChanged(nameof(PersonBio));
            }
        }

        public string PersonSex
        {
            get => _item.Sex;

            set
            {
                _item.Sex = value;
                RaisePropertyChanged(nameof(PersonBio));
            }
        }
    }
}
