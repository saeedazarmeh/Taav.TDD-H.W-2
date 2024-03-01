using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Entities.Patients;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Patients.Contracts.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts.Mapper
{
    public static class PatientMapper
    {
        public static List<PatientResultDTO> PatientsMap(this List<Patient> doctors)
        {
            var patientsDTO = new List<PatientResultDTO>();
            foreach(var doctor in doctors)
            {
                var patientDTO = new PatientResultDTO()
                {
                    PatientId = doctor.Id,
                    FirstName = doctor.FirstName,
                    LastName = doctor.LastName,
                    NationalCode=doctor.NationalCode,
                };
                patientsDTO.Add(patientDTO);
            }
            return patientsDTO;
        }
    }
}
