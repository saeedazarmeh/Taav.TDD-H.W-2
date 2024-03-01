using DoctorAppointment.Services.Doctors.Contracts.Dto;

namespace DoctorAppointment.Services.Patients.Contracts;

public interface DoctorService
{
    Task Add(AddDoctorDto dto);
}