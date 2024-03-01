using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Patients.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Patients
{
    public class UpdatePatientDTOFactory
    {
        public static UpdatePatientDto Create()
        {
            return new UpdatePatientDto()
            {
                FirstName = "dummy-first-name1",
                LastName = "dummy-last-family1",
                NationalCode = "1122558899",
            };
        }
    }
}
