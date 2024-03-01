using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Patients.Contracts.Dto;

namespace DoctorAppointment.Services.Patients.Contracts;

public interface PatientService
{
    Task Add(AddPatientDto dto);
}