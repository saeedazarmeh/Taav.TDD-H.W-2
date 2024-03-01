
using DoctorAppointment.Entities.Patients;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;

namespace PatientAppointment.Persistance.EF.Patients;

public class EFPatientRepository : PatientRepository
{
    private readonly EFDataContext _context;

    public EFPatientRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Patient Patient)
    {
        _context.Patients.Add(Patient);
    }

    public async Task<Patient?> FindById(int id)
    {
        return await _context.Patients.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<bool> IsDuplicatedNationalCod(string nationalCode)
    {
        return await _context.Patients.AnyAsync(_ => _.NationalCode == nationalCode);    
    }

    public async Task<List<Patient>> GetAll()
    {
        return await _context.Patients.ToListAsync();
    }

    public void Update(Patient patient)
    {
        _context.Patients.Update(patient);
    }
}