using DoctorAppointment.Entities.Appoinments;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Appointmens.Cantracts;
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
    }
}
