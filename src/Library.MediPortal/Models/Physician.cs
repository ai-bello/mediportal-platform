using System;
using Library.MediPortal.Services;
namespace Library.MediPortal.Models;

public class Physician
{
    public string? Name { get; set; }
    public string? LicenseNumber { get; set; }
    public DateTime? GraduationDate { get; set; }
    public string? Specializations { get; set; }
    public int Id { get; set; }
    public int[,] Appointment { get; set; } = new int[5, 9];


    public Physician()
    {
        
    }

    public Physician(int id)
    {
        var physicianCopy = PhysicianServiceProxy.Current.Physicians.FirstOrDefault(p => (p?.Id ?? 0) == id);

        if (physicianCopy != null)
        {
            Id = physicianCopy.Id;
            Name = physicianCopy.Name;
            LicenseNumber = physicianCopy.LicenseNumber;
            GraduationDate = physicianCopy.GraduationDate;
            Specializations = physicianCopy.Specializations;
        }
    }

    public string Display
    {
        get
        {
            return ToString();
        }
    }

    public override string ToString()
    {
        return $"[{Id}]. {Name} | {LicenseNumber} | {GraduationDate:MM-dd-yyyy} | {Specializations}\n";
    }

}
