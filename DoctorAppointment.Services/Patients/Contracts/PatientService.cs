using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Patients.Contracts.Dto;
using DoctorAppointment.Services.Patients.Exeptipn;

namespace DoctorAppointment.Services.Patients.Contracts;

public interface PatientService
{
    Task Add(AddPatientDto dto);
    Task Update(int id, UpdatePatientDto dto);

    Task<List<PatientResultDTO>> GetAll();
}