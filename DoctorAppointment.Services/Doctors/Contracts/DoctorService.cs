using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Doctors.Exeptipn;

namespace DoctorAppointment.Services.Patients.Contracts;

public interface DoctorService
{
    Task Add(AddDoctorDto dto);

    Task Update(int id, UpdateDoctorDto dto);

    Task<List<DoctorResultDTO>> GetAll();
}