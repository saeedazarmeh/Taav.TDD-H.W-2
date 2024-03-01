using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Doctors
{
    public class DoctorServiceFactory
    {
        public static DoctorAppService Create(EFDataContext context)
        {
            var reository = new EFDoctorRepository(context);
            var unit = new EFUnitOfWork(context);
            return new DoctorAppService(reository, unit);
        }
    }
}
