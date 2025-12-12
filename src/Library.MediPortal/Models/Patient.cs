using Library.MediPortal.Services;

namespace Library.MediPortal;

public class Patient
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public DateTime? BirthDate { get; set; }
    public string? Race { get; set; }
    public string? Gender { get; set; }
    public int Id { get; set; }

    public List<string?> Diagnoses { get; set; } = new List<string?>();

    public Patient()
    {
        
    }

    public Patient(int id)
    {
        var patientCopy = PatientServiceProxy.Current.Patients.FirstOrDefault(p => (p?.Id ?? 0) == id);

        if (patientCopy != null)
        {
            Id = patientCopy.Id;
            Name = patientCopy.Name;
            Address = patientCopy.Address;
            BirthDate = patientCopy.BirthDate;
            Race = patientCopy.Race;
            Gender = patientCopy.Gender;
            Diagnoses = patientCopy.Diagnoses;
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
        string data1 = $"[{Id}]. {Name} | {Address} | {BirthDate:MM-dd-yyyy}";
        string data2 = $" | {Race} | {Gender}\nDiagnoses:\n";
        string diagnosesList = "";
        foreach (string? d in Diagnoses)
        {
            diagnosesList += $"* {d}\n";
        }
        return data1 + data2 + diagnosesList;
    }

    public string PrintIdName()
    {
        return $"[{Id}]. {Name}\n";
    }


}
