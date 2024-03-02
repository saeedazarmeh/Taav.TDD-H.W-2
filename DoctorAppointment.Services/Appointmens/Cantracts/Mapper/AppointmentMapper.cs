using DoctorAppointment.Entities.Appoinments;
using DoctorAppointment.Services.Appointmens.Cantracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointmens.Cantracts.Mapper
{
    public static class AppointmentMapper
    {
        public static List<AppointmentResultDTO> AppoinmentsMap(this List<Appoinment> appoinments)
        {
            var result = new List<AppointmentResultDTO>();
            foreach (var appointment in appoinments)
            {
                var dto=new AppointmentResultDTO()
                {
                    AppointmentId=appointment.Id,
                    Doctor=appointment.Doctor.FirstName+" "+appointment.Doctor.LastName,
                    Patient=appointment.Patient.FirstName+" "+appointment.Patient.LastName,
                    DaTeTime=appointment.DaTeTime,
                    Paid=appointment.Paid,
                    Price=appointment.Price,
                };
                result.Add(dto);
            }
            return result;
        }
    }
}
