using DoctorAppointment.Entities.Doctors;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Builder.Doctors
{
    public class AddDoctorBuilder
    {
        private readonly Doctor _doctor;
        public AddDoctorBuilder()
        {
            _doctor = new Doctor("dummy-first-name1", "dummy-last-family1", "health", "2280909952");
        }

        public AddDoctorBuilder WithNationalCode(string nationalCode)
        {
            _doctor.Edit(null, null, null, nationalCode);
            return this;
        }
        public Doctor Builder()
        {
            return _doctor;
        }
    }
}
