using PersonWithCars.ViewModel;
using System.Windows;

namespace PersonWithCars.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow()
        {
            this.DataContext = _viewModel = new MainViewModel();
            InitializeComponent();
        }

        private void UpdatePersonButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.IsItNew = false;
            PersonWindow personWindow = new PersonWindow(_viewModel);
            personWindow.ShowDialog();
            
        }

        private void UpdateCarButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.IsItNew = false;
            CarWindow carWindow = new CarWindow(_viewModel);
            carWindow.ShowDialog();
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.IsItNew = true;
            _viewModel.SelectedPerson = new();
            PersonWindow personWindow = new PersonWindow(_viewModel);
            personWindow.ShowDialog();
        }

        private void AddCarButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.IsItNew = true;
            _viewModel.SelectedCar = new();
            CarWindow carWindow = new CarWindow(_viewModel);
            carWindow.ShowDialog();
        }
    }
}