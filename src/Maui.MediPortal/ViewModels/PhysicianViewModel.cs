using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using Library.MediPortal;
using Library.MediPortal.Services;
using Library.MediPortal.Models;
namespace Maui.MediPortal.ViewModels;

public class PhysicianViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Physician?> Physicians
    {
        get
        {
            return new ObservableCollection<Physician?>(PhysicianServiceProxy.Current.Physicians);
        }
    }

    public void Refresh()
    {
        NotifyPropertyChanged(nameof(Physicians));
    }

    public Physician? SelectedPhysician
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
        if (SelectedPhysician == null)
        {
            return;
        }
        PhysicianServiceProxy.Current.Delete(SelectedPhysician.Id);
        NotifyPropertyChanged(nameof(Physicians));
    }
}


