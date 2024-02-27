using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.EntityFrameworkCore;

namespace DoctorAppointment.Persistance.EF.Doctors;

public class EFDoctorRepository : DoctorRepository
{
    private readonly EFDataContext _context;

    public EFDoctorRepository(EFDataContext context)
    {
        _context = context;
    }

    public void Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
    }

    public async Task<Doctor?> FindById(int id)
    {
        return await _context.Doctors.FirstOrDefaultAsync(_ => _.Id == id);
    }

    public async Task<bool> IsDuplicatedNationalCod(string nationalCode)
    {
        return await _context.Doctors.AnyAsync(_ => _.NationalCode == nationalCode);    
    }

    public async Task<List<Doctor>> GetAll()
    {
        return await _context.Doctors.ToListAsync();
    }
}