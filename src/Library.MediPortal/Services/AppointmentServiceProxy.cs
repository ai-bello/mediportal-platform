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


    public Appointment? Create(Appointment? appointment)
    {
        if(appointment==null)
        {
            return null;
        }
        if(appointment.Id<=0)
        {
            var maxId = -1;
            if (appointmentList.Any())
            {
                maxId = appointmentList.Select(a => a?.Id ?? -1).Max();
            }
            else
            {
                maxId = 0;
            }
            appointment.Id = ++maxId;

            appointmentList.Add(appointment);
        }
        else
        {
            var appointmentToEdit = Appointments.FirstOrDefault(p => (p?.Id ?? 0) == appointment.Id);
            if (appointmentToEdit != null)
            {
                var index = Appointments.IndexOf(appointmentToEdit);
                Appointments.RemoveAt(index);
                appointmentList.Insert(index, appointment);
            }
        }


        return appointment;
    }
    
}
