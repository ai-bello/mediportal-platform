using System;

namespace Library.MediPortal.Models;

public class Appointment
{
    public int Id { get; set; }
    public int PhysicianId { get; set; }

    public Physician Physician { get; set; }

    public int PatientId { get; set; }

    public Patient Patient { get; set; }
}
