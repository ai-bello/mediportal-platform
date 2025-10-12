using System.Net.Quic;
using System.Runtime.InteropServices;
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
                    ManagePatients();
                    break;
                case "2":
                    //ManagePhysicians();
                    break;
                case "3":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid entry. Try again.");
                    break;
            }
        } while (!quit);
    }

    public static void MainMenu()
    {
        Console.WriteLine("\n-------Menu-------");
        Console.WriteLine("1. Manage Patients");
        Console.WriteLine("2. Manage Physicians");
        Console.WriteLine("3. Quit");
    }

    public static void PrintPatientMenu()
    {
        Console.WriteLine("\n-------Patients Menu-------");
        Console.WriteLine("1. Create new patient");
        Console.WriteLine("2. Print list of patients");
        Console.WriteLine("3. Update existing patient");
        Console.WriteLine("4. Delete existing patient");
        Console.WriteLine("5. Back to main menu");
    }

    public static void ManagePatients()
    {
        bool goBack = false;
        do
        {
            PrintPatientMenu();
            switch (Console.ReadLine())
            {
                case "1":
                    break;
                case "2":
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "5":
                    goBack = true;
                    break;
            }
        } while (!goBack);
    }

    public static void CreatePatient()
    {
        Patient patient = new Patient();
        Console.WriteLine("Enter the new patient's name: ");
        patient.Name = Console.ReadLine();
        Console.WriteLine("Enter the patients address: ");
        patient.Address = Console.ReadLine();
        int birthYear = int.Parse(Console.ReadLine() ?? "-1");
        int birthMonth = int.Parse(Console.ReadLine() ?? "-1");
        int birthDay = int.Parse(Console.ReadLine() ?? "-1");
        
    }
    
}
