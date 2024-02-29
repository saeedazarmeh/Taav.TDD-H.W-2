using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Test.Tools.Infrastructure.Facrory.InmemoryDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Doctor
{
    public class DoctorService
    {
        public static DoctorAppService Create(EFDataContext context)
        {
            var reository = new EFDoctorRepository(context);
            var unit=new EFUnitOfWork(context);
            return new DoctorAppService(reository, unit);
        }
    }
}
