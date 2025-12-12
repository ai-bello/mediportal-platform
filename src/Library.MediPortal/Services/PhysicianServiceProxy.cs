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

        return physician;
    }
}
