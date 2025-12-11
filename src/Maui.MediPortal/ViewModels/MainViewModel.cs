using System;
using Library.MediPortal;

namespace Maui.MediPortal.ViewModels;

public class MainViewModel
{
    public List<Patient> Patients
    {
        get
        {
            return new List<Patient>
            {
                new Patient {Name="John Doe", Address="1234 St", BirthDate= new DateTime(2000,1,1), Race = "White", Gender= "Male", Id = 1, Diagnoses = { } }
                ,
                new Patient {Name="John Doe", Address="1234 St", BirthDate= new DateTime(2000,1,1), Race = "White", Gender= "Male", Id = 2, Diagnoses = { } }
            };
        }
    }

    public Patient? SelectedPatient
    {
        get; set;
    }
}
