using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Entities.Patients;

namespace DoctorAppointment.Services.Doctors.Contracts;

public interface DoctorRepository
{
    void Add(Doctor doctor);
    void Update(Doctor doctor);
    Task<Doctor?> FindById(int id);
    Task<List<Doctor>> GetAll();
    Task<bool> IsDuplicatedNationalCod(string nationalCode);
}