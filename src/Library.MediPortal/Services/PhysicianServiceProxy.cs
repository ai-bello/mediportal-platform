using System;
using Library.MediPortal.Models;

namespace Library.MediPortal.Services;

public class PhysicianServiceProxy
{
    private List<Physician?> physicianList;

    private PhysicianServiceProxy()
    {
        physicianList = new List<Physician?>();
    }

    private static PhysicianServiceProxy? instance;
    private static object instanceLock = new object();
    public static PhysicianServiceProxy Current
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new PhysicianServiceProxy();
                }
            }
            return instance;
        }
    }
    public List<Physician?> Physicians
    {
        get
        {
            return physicianList;
        }
    }

    public Physician? Create(Physician? physician)
    {
        if (physician == null)
        {
            return null;
        }
        if (physician.Id <= 0)
        {
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
        else
        {
            var physicianToEdit = Physicians.FirstOrDefault(p => (p?.Id ?? 0) == physician.Id);
            if (physicianToEdit != null)
            {
                var index = Physicians.IndexOf(physicianToEdit);
                Physicians.RemoveAt(index);
                physicianList.Insert(index, physician);
            }
        }
        

        return physician;
    }
    public Physician? Delete(int id)
    {
        Physician? physicianToDelete = physicianList.Where(p => p != null).FirstOrDefault(p => p?.Id == id);
        physicianList.Remove(physicianToDelete);
        return physicianToDelete;
    }
}
