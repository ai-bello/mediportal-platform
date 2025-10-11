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
        MainMenu();
        bool quit = false;
        do
        {
            switch (Console.ReadLine())
            {
                case "1":
                    //ManagePatients();
                    break;
                case "2":
                    //ManagePhysicians();
                    break;
                case "3":
                    quit = true;
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
}
