using DoctorAppointment.Entities.Appoinments;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Appointmens.Cantracts;
using DoctorAppointment.Services.Appointmens.Exception;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistance.EF.Appointments
{
    public class EfAppointmentRepository : AppointmentRepository
    {
        private readonly EFDataContext _context;

        public EfAppointmentRepository(EFDataContext context)
        {
            _context = context;
        }

        public void Add(Appoinment appoinment)
        {
            _context.Appoinments.Add(appoinment);
        }

        public async Task<Appoinment> GetAppointment(int id)
        {
            return await _context.Appoinments.FirstOrDefaultAsync(_=>_.Id == id);
        }

        public async Task<List<Appoinment>> GetDayAppointments(DateTime dateTime)
        {
            return await _context.Appoinments.Where(_=>_.DaTeTime.Date== dateTime.Date).ToListAsync();
        }

        public async Task<bool> HasTimeConflictedOrNot(DateTime dateTime)
        {
            var appointments = await GetDayAppointments(dateTime);
            foreach (var appointment in appointments)
            {
                if((appointment.DaTeTime.AddMinutes(30)>dateTime && appointment.DaTeTime < dateTime) 
                    || (appointment.DaTeTime < dateTime.AddMinutes(30) && appointment.DaTeTime > dateTime))
                {
                    return true;
                }
            }

            return false;
        }

        public void Delete(Appoinment appoinment)
        {
            _context.Appoinments.Remove(appoinment);
        }
    }
}
