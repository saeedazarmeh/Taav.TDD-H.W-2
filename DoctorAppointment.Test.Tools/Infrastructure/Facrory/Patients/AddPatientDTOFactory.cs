using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Patients.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Patients
{
    public class AddPatientDTOFactory
    {
        public static AddPatientDto Create(string? natinalCode = null)
        {
            return new AddPatientDto()
            {
                FirstName = "dummy-first-name1",
                LastName = "dummy-last-family1",
                NationalCode = natinalCode ?? "2280909952",
            };
        }
    }
}
