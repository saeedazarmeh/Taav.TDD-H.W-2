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

        public async Task Add(AddAppoinmentDTO appoinmentDTO)
        {
            var appoinment = new Appoinment(appoinmentDTO.PatientId, appoinmentDTO.DoctorId, appoinmentDTO.DaTeTime, appoinmentDTO.Price, appoinmentDTO.Paid);
            if(await _repository.HasTimeConflictedOrNot(appoinmentDTO.DaTeTime))
            {
                throw new TimeConflictedSetAppointmentException();
            }
            _repository.Add(appoinment);
            await _unit.Complete();
        }

    }
}
