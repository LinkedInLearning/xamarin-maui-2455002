using OldFormsApp.Interfaces;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace OldFormsApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private ILocation _Location;

        public event PropertyChangedEventHandler PropertyChanged;

        public MainPageViewModel()
        {
            _Location = DependencyService.Get<ILocation>();
        }

        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }

        private ICommand _RefreshLocationCommand;
        public ICommand RefreshLocationCommand 
        {
            get { return _RefreshLocationCommand ?? (_RefreshLocationCommand = new Command(() => RefreshLocation())); }
        }

        private async void RefreshLocation()
        {
            var location = await _Location.GetLocation();
            CurrentLatitude = location.Latitude;
            CurrentLongitude = location.Longitude;
            OnPropertyChanged(nameof(CurrentLatitude));
            OnPropertyChanged(nameof(CurrentLongitude));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}