using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Doctors.Contracts.Mapper;
using DoctorAppointment.Services.Doctors.Exeptipn;
using DoctorAppointment.Services.Exeptipn;

namespace DoctorAppointment.Services.Doctors;

public class DoctorAppService : DoctorService
{
    private readonly DoctorRepository _repository;
    private readonly UnitOfWork _unitOfWork;

    public DoctorAppService(
        DoctorRepository repository,
        UnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(AddDoctorDto dto)
    {
        if(await _repository.IsDuplicatedNationalCod(dto.NationalCode))
        {
            throw new DuplicateNationalCodeException();
        }
        var doctor = new Doctor(dto.FirstName, dto.LastName, dto.Field, dto.NationalCode);
        _repository.Add(doctor);
        await _unitOfWork.Complete();
    }

    public async Task Update(int id, UpdateDoctorDto dto)
    {
        var doctor = await _repository.FindById(id);
        if(doctor == null)
        {
            throw new DoctorNotFoundException();
        }
        doctor.Edit(dto.FirstName, dto.LastName, dto.Field, dto.NationalCode);

        await _unitOfWork.Complete();
    }

    public async Task<List<DoctorResultDTO>> GetAll()
    {
        var doctors= await _repository.GetAll();
        return doctors.DoctorsMap();
    }
}