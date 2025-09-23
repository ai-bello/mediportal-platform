namespace Library.MediPortal;

public class Patient
{
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? BirthDate { get; set; }
    public string? Race { get; set; }
    public string? Gender { get; set; }
    public int Id { get; set; }

    public List<string?> Diagnoses { get; set; } = new List<string?>();

}
