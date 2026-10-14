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
    public ObservableCollection<PhysicianRowViewModel?> Physicians
    {
        get
        {
            return new ObservableCollection<PhysicianRowViewModel?>(PhysicianServiceProxy.Current.Physicians.Select(p=>new PhysicianRowViewModel(p)));
        }
    }

    public void Refresh()
    {
        NotifyPropertyChanged(nameof(Physicians));
    }

    public PhysicianRowViewModel? SelectedPhysician
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
        PhysicianServiceProxy.Current.Delete(SelectedPhysician?.Model?.Id ?? 0);
        NotifyPropertyChanged(nameof(Physicians));
    }
}


