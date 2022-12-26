using iText.Layout.Element;
using Microsoft.Win32;
using MvvmCross.Commands;
using Pair.App.Desktop.ViewModels.Common;
using Pair.Core.Models;
using Pair.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Automation;

namespace Pair.App.Desktop.ViewModels
{
    public class PersonEditPageViewModel : EditViewModelBase<Person>
    {
        private readonly IInterestsRepository _interestsRepository;

        private readonly IInterestsPersonsRepository _interestsPersonsRepository;

        private InterestsPersons _interestsPersons = new();

        private ObservableCollection<Interest> _interests;

        private Interest _selectedInterest;

        public PersonEditPageViewModel(IPersonsRepository repository, IInterestsRepository interestsRepository, IInterestsPersonsRepository interestsPersonsRepository) : base(repository)
        {
            _interestsRepository = interestsRepository;
            _interestsPersonsRepository = interestsPersonsRepository;
        }

        public ObservableCollection<Interest> Interests
        {
            get => _interests;

            set
            {
                _interests = value;
                RaisePropertyChanged(nameof(Interests));
            }
        }

        public ObservableCollection<Interest> PersonInterests { get; set; }

        public Interest SelectedInterest
        {
            get => _selectedInterest;

            set
            {
                _selectedInterest = value;
                RaisePropertyChanged(nameof(SelectedInterest));
            }
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

        public string ImageLink
        {
            get => _item.ImageUri;

            set
            {
                _item.ImageUri  = value;
                RaisePropertyChanged(nameof(ImageLink));
            }
        }

        public int SocialCredit
        {
            get => _item.SocialCredit;

            set
            {
                _item.SocialCredit = value;
                RaisePropertyChanged(nameof(SocialCredit));
            }
        }

        public IMvxCommand AddImageCommand => new MvxCommand(AddImage, CanAddImage);

        public IMvxCommand AddInteresCommand => new MvxCommand(AddInterest);

        public IMvxCommand RemoveInteresCommand => new MvxCommand(RemoveInterest);

        private async void AddImage()
        {
            var storePath = @$"{Environment.CurrentDirectory}\ImagesStore\{_item.Id}{_item.Name}";
            
            FileDialog fileDialog = new OpenFileDialog();

            fileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";

            fileDialog.ShowDialog();

            if (fileDialog.FileName != "")
            {
                File.Move(fileDialog.FileName, storePath);
                
                ImageLink = storePath;
            }
        }

        protected override async void Add()
        {
            _interestsPersons.PersonId = (int)await _repository.Insert(_item);
            _interestsPersons.InterestId = SelectedInterest.Id;
            await _interestsPersonsRepository.Insert(_interestsPersons);
        }

        protected override async void Edit()
        {
            _interestsPersons.PersonId = _item.Id;
            await _repository.Update(_item);
            _interestsPersons.InterestId = SelectedInterest.Id;
            await _interestsPersonsRepository.Update(_interestsPersons);
        }

        private async void AddInterest()
        {
            PersonInterests = new ObservableCollection<Interest>(await _interestsRepository.Get());
            Interests = new ObservableCollection<Interest>(await _interestsRepository.Get());

            if (SelectedInterest is not null)
            {
               
            }

            RaisePropertyChanged(nameof(PersonInterests));
        }

        private void RemoveInterest()
        {
            RaisePropertyChanged(nameof(PersonInterests));
        }

        private bool CanAddImage() =>
            !string.IsNullOrEmpty(PersonName); 
    }
}
