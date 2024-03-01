using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointment.Services.Patients;
using PatientAppointment.Persistance.EF.Patients;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Patients
{
    public class PatientServiceFactory
    {
        public static PatientAppService Create(EFDataContext context)
        {
            var reository = new EFPatientRepository(context);
            var unit = new EFUnitOfWork(context);
            return new PatientAppService(reository, unit);
        }
    }
}
