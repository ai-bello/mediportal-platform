using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Library.MediPortal.Services;


namespace Maui.MediPortal.ViewModels;

public class PatientViewModel : INotifyPropertyChanged
{

    public ObservableCollection<PatientRowViewModel?> Patients
    {
        get
        {
            return new ObservableCollection<PatientRowViewModel?>(PatientServiceProxy.Current.Patients.Select(p => new PatientRowViewModel(p)));
        }
    }

    public void Refresh()
    {
        NotifyPropertyChanged(nameof(Patients));
    }

    public PatientRowViewModel? SelectedPatient { get; set; }

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
        PatientServiceProxy.Current.Delete(SelectedPatient?.Model?.Id ?? 0);
        NotifyPropertyChanged(nameof(Patients));
    }
}
