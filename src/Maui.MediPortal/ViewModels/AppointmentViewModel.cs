using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
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

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
