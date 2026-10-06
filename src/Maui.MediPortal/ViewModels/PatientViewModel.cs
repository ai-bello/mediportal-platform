using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Library.MediPortal.Models;
using Library.MediPortal.Services;
using System.Windows.Input;

namespace Maui.MediPortal.ViewModels;

public class PatientViewModel : INotifyPropertyChanged
{
    public Patient? Model { get; set; }
    public ICommand? DeleteCommand { get; set; }
    public ICommand? EditCommand { get; set; }

    public PatientViewModel()
    {
        Model = new Patient();
        SetUpCommands();
    }

    public PatientViewModel(Patient? model)
    {
        Model = model;
        SetUpCommands();
    }
    
    private void SetUpCommands()
    {
        DeleteCommand = new Command(DoDelete);
        EditCommand = new Command((p) => DoEdit(p as PatientViewModel));
    }

    private void DoDelete()
    {
        if(Model.Id>0)
        {
            PatientServiceProxy.Current.Delete(Model.Id);
            Shell.Current.GoToAsync("//PatientsView");
        }
    }

    private void DoEdit(PatientViewModel? pvm)
    {
        if (pvm == null)
        {
            return;
        }
        var selectedPatientId = pvm?.Model?.Id ?? 0;
        Shell.Current.GoToAsync($"//AddPatientsView?patientId={selectedPatientId}");
    }

    public ObservableCollection<PatientViewModel?> Patients
    {
        get
        {
            return new ObservableCollection<PatientViewModel?>(PatientServiceProxy.Current.Patients.Select(p=>new PatientViewModel(p)));
        }
    }

    public void Refresh()
    {
        NotifyPropertyChanged(nameof(Patients));
    }

    public PatientViewModel? SelectedPatient{ get; set; }

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
