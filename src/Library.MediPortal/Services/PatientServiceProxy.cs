using System;
using System.ComponentModel;

namespace Library.MediPortal.Services;

public class PatientServiceProxy
{
    private List<Patient?> patientList;

    private PatientServiceProxy()
    {
        patientList = new List<Patient?>();
    }
    private static PatientServiceProxy? instance;
    private static object instanceLock = new object();
    public static PatientServiceProxy Current
    {
        get
        {
            lock(instanceLock)
            {
                if (instance == null)
                {
                    instance = new PatientServiceProxy();
                }
            }
            return instance;
        }
    }

    public List<Patient?> Patients
    {
        get
        {
            return patientList;
        }

    }

    public Patient? Create(Patient? patient)
    {
        if (patient == null)
        {
            return null;
        }
        if (patient.Id <= 0)
        {
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
        else
        {
            var patientToEdit = Patients.FirstOrDefault(p => (p?.Id ?? 0) == patient.Id);
            if (patientToEdit != null)
            {
                var index = Patients.IndexOf(patientToEdit);
                Patients.RemoveAt(index);
                patientList.Insert(index, patient);
            }
        }
        

        return patient;
    }

    public Patient? Delete(int id)
    {
        Patient? patientToDelete = patientList.Where(p => p != null).FirstOrDefault(p => p?.Id == id);
        patientList.Remove(patientToDelete);
        return patientToDelete;
    }
}
