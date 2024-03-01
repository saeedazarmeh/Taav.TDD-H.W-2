using DoctorAppointment.Entities.Appoinments;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using DoctorAppointment.Test.Tools.Infrastructure.Facrory.Appointmet;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Unit.Tests
{
    public class AppointmentServiceTest
    {

        [Fact]
        public async Task SetAppointment_Set_Appointment_Properly()
        {
            var db=new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = AppointmentServiceFactory.Create(context);
            var appointmentDTO = AddAppoinmentDTOFactory.Create();

            await sut.Add(appointmentDTO);

            var actual=readContext.Appoinments.First();
            actual.DoctorId.Should().Be(appointmentDTO.DoctorId);
            actual.PatientId.Should().Be(appointmentDTO.PatientId);
            actual.Price.Should().Be(appointmentDTO.Price);
            actual.Paid.Should().Be(appointmentDTO.Paid);
            actual.DaTeTime.Should().Be(appointmentDTO.DaTeTime);
        }
    }





  



   

  
}
