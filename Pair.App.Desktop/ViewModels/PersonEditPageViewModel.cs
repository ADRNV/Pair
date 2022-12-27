using Dapper;
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
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;

namespace Pair.App.Desktop.ViewModels
{
    public class PersonEditPageViewModel : EditViewModelBase<Person>
    {
        private readonly IInterestsRepository _interestsRepository;

        private readonly IInterestsPersonsRepository _interestsPersonsRepository;

        private List<InterestsPersons> _interestsPersons = new();

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

        public ObservableCollection<Interest> PersonInterests { get; set; } = new();

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

        public IMvxCommand RemoveInteresCommand => new MvxCommand(RemoveInterest, CanModifyInterests);

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
            _item.Id = (int)await _repository.Insert(_item);

            foreach (var interestPerson in _interestsPersons)
            {
                await _interestsPersonsRepository.Insert(interestPerson);
            }
            _interestsPersons.Clear();
        }

        protected override async void Edit()
        {
            var interestsPersons = new InterestsPersons();
            interestsPersons.PersonId = _item.Id;
            await _repository.Update(_item);
            interestsPersons.InterestId = SelectedInterest.Id;
            await _interestsPersonsRepository.Update(interestsPersons);
        }

        private async void AddInterest()
        {
            if (Interests is null)
            {
                Interests = new ObservableCollection<Interest>(await _interestsRepository.Get());
            }

            if(SelectedInterest is not null)
            {
                PersonInterests.Add(SelectedInterest);

                if (_item.Id == 0)
                {
                    MessageBox.Show("Нужно добавить человека в БД");
                    return;
                }
                
                var interestId = SelectedInterest.Id;

                _interestsPersons.Add(new InterestsPersons
                {
                    PersonId = _item.Id,
                    InterestId = interestId

                });
            }
          
            RaisePropertyChanged(nameof(PersonInterests));
        }

        private async void RemoveInterest()
        {
            PersonInterests.Remove(SelectedInterest);

            var pairs = await _interestsPersonsRepository.Get();

            var personPair = pairs.AsList().Find(i => i.PersonId == _item.Id && i.InterestId == _selectedInterest.Id);
            
            await _interestsPersonsRepository.Delete(personPair);
            
            RaisePropertyChanged(nameof(PersonInterests));
        }

        private bool CanAddImage() =>
            !string.IsNullOrEmpty(PersonName);

        private bool CanModifyInterests() =>
            SelectedInterest is not null;
    }
}
