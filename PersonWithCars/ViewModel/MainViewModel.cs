using PersonWithCars.Common;
using PersonWithCars.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace PersonWithCars.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        public bool IsItNew { get; set; }
        public ObservableCollection<PersonDTO> Persons { get; set; } = [];
        public ObservableCollection<CarDTO> Cars { get; set; } = [];

        public List<CarDTO> carsMock = [
                                                  new CarDTO { Id = 1, CarBrand = "Opel", LicensePlate = "HUN-123", PersonId = 1 },
                                                  new CarDTO { Id = 2, CarBrand = "Toyota", LicensePlate = "TCM-123", PersonId = 1 },
                                                  new CarDTO { Id = 3, CarBrand = "Suzuki", LicensePlate = "HUN-414", PersonId = 2 },
                                                  new CarDTO { Id = 1, CarBrand = "BMW", LicensePlate = "UML-153", PersonId = 3 },
                                                 ];
        private PersonDTO _selectedPerson;
        public PersonDTO SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                SetField(ref _selectedPerson, value);
                FillCars(_selectedPerson);
            }
        }

        public CarDTO SelectedCar { get; set; }

        private ICollectionView _personsView;
        public ICollectionView PersonsView
        {
            get
            {
                if (_personsView == null)
                {
                    _personsView = CollectionViewSource.GetDefaultView(Persons);
                }
                return _personsView;
            }
        }

        private ICollectionView _carsView;
        public ICollectionView CarsView
        {
            get
            {
                if (_carsView == null)
                {
                    _carsView = CollectionViewSource.GetDefaultView(Cars);
                }
                return _carsView;
            }
        }

        public RelayCommand RemoveCarCommand { get; set; }
        public RelayCommand RemovePersonCommand { get; set; }

        public RelayCommand AddOrModifyCarCommand { get; set; }
        public RelayCommand AddOrModifyPersonCommand { get; set; }

        public MainViewModel()
        {
            var date1 = DateTime.ParseExact("1989.02.02", "yyyy.MM.dd",
                                        System.Globalization.CultureInfo.InvariantCulture);
            var date2 = DateTime.ParseExact("2000.05.21", "yyyy.MM.dd",
                                      System.Globalization.CultureInfo.InvariantCulture);
            var date3 = DateTime.ParseExact("1999.10.01", "yyyy.MM.dd",
                                      System.Globalization.CultureInfo.InvariantCulture);

            Persons.Add(new PersonDTO { Id = 1, FirstName = "John", LastName = "Don", BirthDay = date1, PAddress = "1113 Budapest Fiumei street 23." });
            Persons.Add(new PersonDTO { Id = 2, FirstName = "Test1", LastName = "Test1", BirthDay = date2, PAddress = "1121 Budapest Rakoczi street 23." });
            Persons.Add(new PersonDTO { Id = 3, FirstName = "Test2", LastName = "Test2", BirthDay = date3, PAddress = "1143 Budapest Test street 23." });

            RemovePersonCommand = new RelayCommand(RemovePersonButtonOnClick, (obj) => true);
            RemoveCarCommand = new RelayCommand(RemoveCarButtonOnClick, (obj) => true);

            AddOrModifyCarCommand = new RelayCommand(AddOrModifyCarButtonOnClick, (obj) => true);
            AddOrModifyPersonCommand = new RelayCommand(AddOrModifyPersonButtonOnClick, (obj) => true);
        }

        private void AddOrModifyPersonButtonOnClick(object obj)
        {
            PersonsView.Refresh();
            if (IsItNew)
            {
                SelectedPerson.Id = Persons.Max(x => x.Id) + 1;
                Persons.Add(SelectedPerson);
            }
        }

        private void AddOrModifyCarButtonOnClick(object obj)
        {
            CarsView.Refresh();
            if (IsItNew)
            {
                SelectedCar.Id = carsMock.Max(x => x.Id) + 1;
                SelectedCar.PersonId = SelectedPerson.Id;
                Cars.Add(SelectedCar);
                carsMock.Add(SelectedCar);
            }
        }

        private void RemovePersonButtonOnClick(object obj)
        {
            Cars.Clear();
            Persons.Remove(SelectedPerson);
        }

        private void RemoveCarButtonOnClick(object obj)
        {
            Cars.Remove(SelectedCar);
        }

        public void FillCars(PersonDTO selectedPerson)
        {
            var currentPersonCars = carsMock.Where(x => x.PersonId == selectedPerson?.Id);
            if (currentPersonCars.Any())
            {
                Cars.Clear();
                foreach (var item in currentPersonCars)
                {
                    Cars.Add(item);
                }
            }
        }
    }
}
