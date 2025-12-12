using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Library.MediPortal;
using Library.MediPortal.Services;

namespace Maui.MediPortal.ViewModels;

public class PatientViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Patient?> Patients
    {
        get
        {
            return new ObservableCollection<Patient?>(PatientServiceProxy.Current.Patients);
        }
    }

    public void Refresh()
    {
        NotifyPropertyChanged("Patients");
    }

    public Patient? SelectedPatient
    {
        get; set;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void Delete()
    {
        if (SelectedPatient == null)
        {
            return;
        }
        PatientServiceProxy.Current.Delete(SelectedPatient.Id);
        NotifyPropertyChanged("Patients");
    }
}
