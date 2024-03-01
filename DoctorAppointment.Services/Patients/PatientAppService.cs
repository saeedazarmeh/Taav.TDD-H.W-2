using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Entities.Patients;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Doctors.Contracts.Mapper;
using DoctorAppointment.Services.Doctors.Exeptipn;
using DoctorAppointment.Services.Patients.Contracts;
using DoctorAppointment.Services.Patients.Contracts.Dto;
using DoctorAppointment.Services.Patients.Contracts.Mapper;
using DoctorAppointment.Services.Patients.Exeptipn;

namespace DoctorAppointment.Services.Patients;

public class PatientAppService : PatientService
{
    private readonly PatientRepository _repository;
    private readonly UnitOfWork _unitOfWork;

    public PatientAppService(
        PatientRepository repository,
        UnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task Add(AddPatientDto dto)
    {
        if(await _repository.IsDuplicatedNationalCod(dto.NationalCode))
        {
            throw new DuplicateNationalCodeException();
        }
        var patient = new Patient(dto.FirstName, dto.LastName, dto.NationalCode);
        _repository.Add(patient);
        await _unitOfWork.Complete();
    }

    public async Task Update(int id, UpdatePatientDto dto)
    {
        var patient = await _repository.FindById(id);
        if(patient == null)
        {
            throw new PatientNotFoundException();
        }
        patient.Edit(dto.FirstName, dto.LastName, dto.NationalCode);
        _repository.Update(patient);
        await _unitOfWork.Complete();
    }

    public async Task<List<PatientResultDTO>> GetAll()
    {
        var patients= await _repository.GetAll();
        return patients.PatientsMap();
    }
}