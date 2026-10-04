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
        public AppointmentViewModel()
        {

        }

        public AppointmentViewModel(int id)
        {
            var appointmentCopy = AppointmentServiceProxy.Current.Appointments.FirstOrDefault(a => (a?.Id ?? 0) == id);

            if(appointmentCopy!=null)
            {
                SelectedPatient = Patients.FirstOrDefault(p => (p?.Id ?? 0) == appointmentCopy.PatientId);
                SelectedPhysician = Physicians.FirstOrDefault(p => (p?.Id ?? 0) == appointmentCopy.PhysicianId);
                SelectedDate = appointmentCopy.DateTime?.Date;
                SelectedTime = appointmentCopy.DateTime?.TimeOfDay;
            }
        }
        public ObservableCollection<Appointment?> Appointments
        {
           get
            {
                return new ObservableCollection<Appointment?>(AppointmentServiceProxy.Current.Appointments);
            }
        }

        public ObservableCollection<Patient?> Patients
        {
            get
            {
                return new ObservableCollection<Patient?>(PatientServiceProxy.Current.Patients);
            }
        }

        public ObservableCollection<Physician?> Physicians
        {
            get
            {
                return new ObservableCollection<Physician?>(PhysicianServiceProxy.Current.Physicians);
            }
        }
        public Patient? SelectedPatient { get; set; }
        public Physician? SelectedPhysician { get; set; }

        public DateTime? MinimumSelectedDate => DateTime.Today;
        public DateTime? SelectedDate { get; set; }

        public ObservableCollection<TimeSpan> AvailableTimes => new ObservableCollection<TimeSpan>(Enumerable.Range(9, 8).Select(hour => TimeSpan.FromHours(hour)));

        public TimeSpan? SelectedTime { get; set; }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Appointments));
        }

        public Appointment? SelectedAppointment
        {
            get; set;
        }

        public event PropertyChangedEventHandler? PropertyChanged;


        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
