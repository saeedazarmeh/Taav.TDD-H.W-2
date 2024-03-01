using DoctorAppointment.Services.Appointmens.Cantracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointmens.Cantracts
{
    public interface AppointmentService
    {
        Task Add(AddAppoinmentDTO appoinmentDTO);
    }
}
