using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Library.MediPortal.Models;
using Library.MediPortal.Services;

namespace Maui.MediPortal.ViewModels
{
    public class AppointmentViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Appointment?> Appointments
        {
           get
            {
                return new ObservableCollection<Appointment?>(AppointmentServiceProxy.Current.Appointments);
            }
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Appointments));
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
