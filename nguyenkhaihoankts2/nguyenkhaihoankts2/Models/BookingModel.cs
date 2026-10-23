using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WinFormsApp.Models
{
    public class BookingModel : INotifyPropertyChanged
    {
        private string _bookingId;
        private string _customerName;
        private string _identityCard;
        private string _roomType;
        private DateTime _checkInDate;
        private int _stayDays;
        private decimal _pricePerNight;

        public string BookingId
        {
            get => _bookingId;
            set { _bookingId = value; OnPropertyChanged(); }
        }

        public string CustomerName
        {
            get => _customerName;
            set { _customerName = value; OnPropertyChanged(); }
        }

        public string IdentityCard
        {
            get => _identityCard;
            set { _identityCard = value; OnPropertyChanged(); }
        }

        public string RoomType
        {
            get => _roomType;
            set { _roomType = value; OnPropertyChanged(); }
        }

        public DateTime CheckInDate
        {
            get => _checkInDate;
            set { _checkInDate = value; OnPropertyChanged(); }
        }

        public int StayDays
        {
            get => _stayDays;
            set { _stayDays = value; OnPropertyChanged(); }
        }

        public decimal PricePerNight
        {
            get => _pricePerNight;
            set { _pricePerNight = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}