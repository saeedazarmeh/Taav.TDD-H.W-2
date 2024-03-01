using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Entities.Patients;

namespace DoctorAppointment.Services.Patients.Contracts;

public interface PatientRepository
{
    void Add(Patient patient);
    void Update(Patient patient);
    Task<Patient?> FindById(int id);
    Task<List<Patient>> GetAll();
    Task<bool> IsDuplicatedNationalCod(string nationalCode);
}