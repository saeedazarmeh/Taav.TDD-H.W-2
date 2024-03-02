using DoctorAppointment.Contracts.Interfaces;
using DoctorAppointment.Entities.Appoinments;
using DoctorAppointment.Services.Appointmens.Cantracts.DTO;
using DoctorAppointment.Services.Appointmens.Cantracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DoctorAppointment.Services.Appointmens.Exception;
using DoctorAppointment.Services.Appointmens.Cantracts.Mapper;

namespace DoctorAppointment.Services.Appointmens
{
    public class AppointmentAppService : AppointmentService
    {
        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unit;

        public AppointmentAppService(AppointmentRepository repository, UnitOfWork unit)
        {
            _repository = repository;
            _unit = unit;
        }

        public async Task SetAppointment(AddAppoinmentDTO appoinmentDTO)
        {
            var appoinment = new Appoinment(appoinmentDTO.PatientId, appoinmentDTO.DoctorId, appoinmentDTO.DaTeTime, appoinmentDTO.Price, appoinmentDTO.Paid);
            if(await _repository.HasTimeConflictedOrNot(appoinmentDTO.DaTeTime))
            {
                throw new TimeConflictedSetAppointmentException();
            }
            _repository.Add(appoinment);
            await _unit.Complete();
        }

        public async Task CancellAppointment(int id)
        {
            var appointment =await _repository.GetAppointment(id);
            if(appointment == null)
            {
                throw new AppointmentNotFoundException();
            }
            _repository.Delete(appointment);
            _unit.Complete();

        }

        public async Task<List<AppointmentResultDTO>> GetDayAppointments(DateTime dateTime)
        {
           var appointments=await _repository.GetDayAppointmentsWhitDoctorAndPatient(dateTime);
            return appointments.AppoinmentsMap();

        }

    }
}
