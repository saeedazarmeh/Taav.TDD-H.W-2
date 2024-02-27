using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts.Mapper
{
    public static class DoctorMapper
    {
        public static List<DoctorResultDTO> DoctorsMap(this List<Doctor> doctors)
        {
            var doctorsDTO= new List<DoctorResultDTO>();
            foreach(var doctor in doctors)
            {
                var doctorDTO=new DoctorResultDTO()
                {
                    DoctorId = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    Field = doctor.Field,
                    NationalCode=doctor.NationalCode,
                };
                doctorsDTO.Add(doctorDTO);
            }
            return doctorsDTO;
        }
    }
}
