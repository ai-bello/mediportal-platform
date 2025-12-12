using System;
using System.ComponentModel;
using Library.MediPortal.Models;

namespace Library.MediPortal.Services;

public class AppointmentServiceProxy
{
    private List<Appointment?> appointmentList;

    private AppointmentServiceProxy()
    {
        appointmentList = new List<Appointment?>();
    }

    private static AppointmentServiceProxy? instance;
    private static object instanceLock = new object();

    public static AppointmentServiceProxy Current
    {
        get
        {
            lock (instanceLock)
            {
                if (instance == null)
                {
                    instance = new AppointmentServiceProxy();
                }
            }
            return instance;
        }
    }
    public List<Appointment?> Appointments
    {
        get
        {
            return appointmentList;
        }
    }
}
