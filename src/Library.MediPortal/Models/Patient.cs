using System.Net.Mail;

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


}
