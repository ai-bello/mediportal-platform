using System;

namespace Library.MediPortal.Models;

public class Physician
{
    public string? Name { get; set; }
    public string? LicenseNumber { get; set; }
    public DateTime? GraduationDate { get; set; }
    public string? Specializations { get; set; }

}
