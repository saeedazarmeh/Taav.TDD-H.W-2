using DoctorAppointment.Persistance.EF.Appointments;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Appointmens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Appointmet
{
    public class AppointmentServiceFactory
    {
        public static AppointmentAppService Create(EFDataContext context)
        {
            var repository = new EfAppointmentRepository(context);
            var unit = new EFUnitOfWork(context);
            return new AppointmentAppService(repository, unit);
        }
    }
}
