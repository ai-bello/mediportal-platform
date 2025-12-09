using System;

namespace Library.MediPortal.Models;

public class Physician
{
    public string? Name { get; set; }
    public string? LicenseNumber { get; set; }
    public DateTime? GraduationDate { get; set; }
    public string? Specializations { get; set; }
    public int Id { get; set; }
    public int[,] Appointment { get; set; } = new int[5, 9];

    public override string ToString()
    {
        return $"[{Id}]. {Name}\n";
    }

}
