using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Entities.Patients;
using DoctorAppointment.Test.Tools.Infrastructure.Builder.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Builder.Patients
{
    public class AddPatientBuilder
    {
        private readonly Patient _patient;
        public AddPatientBuilder()
        {
            _patient = new Patient("dummy-first-name1", "dummy-last-family1",  "2280909952");
        }

        public AddPatientBuilder WithNationalCode(string nationalCode)
        {
            _patient.Edit(null, null, nationalCode);
            return this;
        }
        public Patient Builder()
        {
            return _patient;
        }
    }
}
