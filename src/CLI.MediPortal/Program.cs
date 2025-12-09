using Library.MediPortal;
using Library.MediPortal.Models;

namespace CLI.MediPortal;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nWelcome to MediPortal!");
        List<Patient?> patientList = new List<Patient?>();
        List<Physician?> physicianList = new List<Physician?>();
        bool quit = false;
        do
        {
            MainMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    ManagePatients(patientList);
                    break;
                case "2":
                    ManagePhysicians(physicianList);
                    break;
                case "3":
                    MakeAppointment(physicianList);
                    break;
                case "4":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid entry. Try again.");
                    break;
            }
        } while (!quit);
    }

    private static void ManagePhysicians(List<Physician?> physicianList)
    {
        bool goBack = false;
        do
        {
            PrintPhysicianMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    CreatePhysician(physicianList);
                    break;
                case "2":
                    ViewPhysicians(physicianList);
                    break;
                case "3":
                    goBack = true;
                    break;
                default:
                    goBack = true;
                    break;
            }
        } while (!goBack);
    }

    public static void MakeAppointment(List<Physician?> physicianList) {
        foreach(Physician? p in physicianList) {
            Console.Write(p);
        }
    }

    public static void PrintPhysicianMenu()
    {
        Console.WriteLine("\n------Physicians Menu------");
        Console.WriteLine("1. Create new physician");
        Console.WriteLine("2. View all physicians");
        Console.WriteLine("3. Back to main menu");
    }

    public static void CreatePhysician(List<Physician?> physicianList)
    {
        Physician physician = new Physician();
        Console.WriteLine("Enter the name of the new physician's name: ");
        physician.Name = Console.ReadLine();
        Console.WriteLine("Enter the physician's license number: ");
        physician.LicenseNumber = Console.ReadLine();
        Console.WriteLine("Enter the physician's graduation date: ");
        DateTime gd;
        while (true)
        {
            string? input = Console.ReadLine();
            if (DateTime.TryParse(input, out gd))
            {
                physician.GraduationDate = gd;
                Console.WriteLine("Successful entry.");
                break;
            }
            Console.WriteLine("Invalid entry. Try again.");
        }
        Console.WriteLine("Enter the physician's specialization: ");
        physician.Specializations = Console.ReadLine();
        int maxId = -1;
        if (physicianList.Any())
        {
            maxId = physicianList.Select(p => p?.Id ?? -1).Max();
        }
        else
        {
            maxId = 0;
        }
        physician.Id = ++maxId;

        physicianList.Add(physician);
    }

    public static void ViewPhysicians(List<Physician?> physicianList)
    {
        foreach(Physician? p in physicianList) {
            Console.Write(p);
        }
    }
    public static void MainMenu()
    {
        Console.WriteLine("\n-------Menu-------");
        Console.WriteLine("1. Manage Patients");
        Console.WriteLine("2. Manage Physicians");
        Console.WriteLine("3. Make Appointment w/ Physician");
        Console.WriteLine("4. Quit");
    }

    public static void PrintPatientMenu()
    {
        Console.WriteLine("\n-------Patients Menu-------");
        Console.WriteLine("1. Create new patient");
        Console.WriteLine("2. View all patients");
        Console.WriteLine("3. Update patient");
        Console.WriteLine("4. Delete patient");
        Console.WriteLine("5. Back to main menu");
    }

    public static void ManagePatients(List<Patient?> patientList)
    {
        bool goBack = false;
        do
        {
            PrintPatientMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    CreatePatient(patientList);
                    break;
                case "2":
                    ViewPatients(patientList);
                    break;
                case "3":
                    UpdatePatient(patientList);
                    break;
                case "4":
                    DeletePatient(patientList);
                    break;
                case "5":
                    goBack = true;
                    break;
            }
        } while (!goBack);
    }

    public static void CreatePatient(List<Patient?> patientList)
    {
        Patient patient = new Patient();
        Console.WriteLine("Enter the new patient's name: ");
        patient.Name = Console.ReadLine();
        Console.WriteLine("Enter the patients address: ");
        patient.Address = Console.ReadLine();
        Console.WriteLine("Enter the patient's birthday (MM-DD-YYYY): ");
        DateTime bd; //variable that TryParse will accept
        while (true)
        {
            string? input = Console.ReadLine();
            if (DateTime.TryParse(input, out bd))
            {
                patient.BirthDate = bd;
                Console.WriteLine("Successful entry.");
                break;
            }
            Console.WriteLine("Invalid entry. Try again.");
        }
        Console.WriteLine("Enter the patient's race: ");
        patient.Race = Console.ReadLine();
        Console.WriteLine("Enter the patient's gender: ");
        patient.Gender = Console.ReadLine();
        while (true)
        {
            Console.WriteLine("Enter the patient's diagnoses and enter 'x' if done: ");
            string? input = Console.ReadLine();
            if (input?.ToLower() != "x")
            {
                patient.Diagnoses.Add(input);
            }
            else
            {
                break;
            }
        }
        var maxId = -1;
        if (patientList.Any())
        {
            maxId = patientList.Select(p => p?.Id ?? -1).Max();
        }
        else
        {
            maxId = 0;
        }
        patient.Id = ++maxId;

        patientList.Add(patient);
    }

    public static void ViewPatients(List<Patient?> patientList)
    {
        foreach (Patient? p in patientList)
        {
            Console.WriteLine(p);
        }
    }

    public static void UpdatePatient(List<Patient?> patientList)
    {
        Console.WriteLine("Select the ID of the patient you would like to update: ");
        patientList.ForEach(Console.WriteLine);
        Console.WriteLine("Patient to update (Id): ");
        string? selection = Console.ReadLine();
        if (int.TryParse(selection, out int IdSelected))
        {
            Patient? patientToUpdate = patientList.Where(p => p != null).FirstOrDefault(p => p?.Id == IdSelected);
            bool goBack = false;
            do
            {
                Console.WriteLine(patientToUpdate);
                UpdatePatientMenu();
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Enter the new patient's name: ");
                        if (patientToUpdate != null)
                        {
                            patientToUpdate.Name = Console.ReadLine();
                        }
                       
                        break;
                    case "2":
                        Console.WriteLine("Enter the patients address: ");
                        if (patientToUpdate != null)
                        {
                            patientToUpdate.Address = Console.ReadLine();
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter the patient's birthday (MM-DD-YYYY): ");
                        DateTime bd; //variable that TryParse will accept
                        string? input = Console.ReadLine();
                        if (DateTime.TryParse(input, out bd) && patientToUpdate != null)
                        {
                            patientToUpdate.BirthDate = bd;
                            Console.WriteLine("Successful entry.");
                            break;
                        }
                        Console.WriteLine("Invalid entry. Try again.");
                        break;
                    case "4":
                        Console.WriteLine("Enter the patient's race: ");
                        if (patientToUpdate != null)
                        {
                            patientToUpdate.Race = Console.ReadLine();
                        }  
                        break;
                    case "5":
                        Console.WriteLine("Enter the patient's gender: ");
                        if (patientToUpdate != null)
                        {
                            patientToUpdate.Gender = Console.ReadLine();
                        }
                        break;
                    case "6":
                        string? newDiagnoses = Console.ReadLine();
                        if (newDiagnoses != null && patientToUpdate!=null)
                        {
                            patientToUpdate.Diagnoses.Add(newDiagnoses);
                        }
                        break;
                    case "7":
                        goBack = true;
                        break;
                    default:
                        Console.WriteLine("Invalid entry.");
                        goBack = true;
                        break;
                }
            } while (!goBack);
        }

    }

    public static void UpdatePatientMenu()
    {
        Console.WriteLine("What would you like to update? ");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Address");
        Console.WriteLine("3. Birthdate");
        Console.WriteLine("4. Race");
        Console.WriteLine("5. Gender");
        Console.WriteLine("6. Add Diagnoses"); 
        Console.WriteLine("7. Done"); 
    }

    public static void DeletePatient(List<Patient?> patientList)
    {
        patientList.ForEach(patient => Console.Write(patient?.PrintIdName())); 
        Console.WriteLine("Patient to delete (Id): ");
        string? selection = Console.ReadLine();
        int IdSelected = int.Parse(selection ?? "0");
        Patient? patientToDelete = patientList.Where(p => p != null).FirstOrDefault(p => p?.Id == IdSelected);
        patientList.Remove(patientToDelete);
    }
    
}