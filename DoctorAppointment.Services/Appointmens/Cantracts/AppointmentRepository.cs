﻿using DoctorAppointment.Entities.Appoinments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointmens.Cantracts
{
    public interface AppointmentRepository
    {
        void Add(Appoinment appoinment);
        Task<List<Appoinment>> GetDayAppointments(DateTime dateTime);
        Task<List<Appoinment>> GetDayAppointmentsWhitDoctorAndPatient(DateTime dateTime);
        Task<bool> HasTimeConflictedOrNot(DateTime dateTime);
        Task<Appoinment> GetAppointment(int id);
        void Delete(Appoinment appoinment);
    }
}
