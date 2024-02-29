using DoctorAppointment.Services.Doctors.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Doctor
{
    public class AddDoctorDTOFactory
    {
        public static AddDoctorDto Create(string? natinalCode=null)
        {
            return new AddDoctorDto()
            {
                FirstName ="dummy-first-name1",
                LastName = "dummy-last-family1" ,
                Field ="health",
                NationalCode = natinalCode??"2280909952",
            };
        }
    }
}
