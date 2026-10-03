using System;

namespace Library.MediPortal.Models;

public class Appointment
{
    public int Id { get; set; }
    public int PhysicianId { get; set; }

    public Physician Physician { get; set; }

    public int PatientId { get; set; }

    public Patient Patient { get; set; }

    public DateTime? DateTime { get; set; }

    public override string ToString()
    {
        if(Patient== null || Physician == null)
        {
            return $"[{Id}]. Appointment with PhysicianId: {PhysicianId} and PatientId: {PatientId} at {DateTime}";
        }
        else
        {
            return $"[{Id}]. {Patient.Name} with Dr. {Physician.Name} at {DateTime}";
        }
    }
}
