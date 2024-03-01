using DoctorAppointment.Entities.Appoinments;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Appointmens.Exception;
using DoctorAppointment.Test.Tools.Infrastructure.Builder.Appointments;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using DoctorAppointment.Test.Tools.Infrastructure.Facrory.Appointmet;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
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
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = AppointmentServiceFactory.Create(context);
            var appointmentDTO = AddAppoinmentDTOFactory.Create();

            await sut.SetAppointment(appointmentDTO);

            var actual = readContext.Appoinments.First();
            actual.DoctorId.Should().Be(appointmentDTO.DoctorId);
            actual.PatientId.Should().Be(appointmentDTO.PatientId);
            actual.Price.Should().Be(appointmentDTO.Price);
            actual.Paid.Should().Be(appointmentDTO.Paid);
            actual.DaTeTime.Should().Be(appointmentDTO.DaTeTime);
        }

        [Fact]
        public async Task SetAppointment_Should_Throw_TimeConflictedSetAppointmentException_Because_of_Time_Confilict()
        {
            var datetime1 = new DateTime(2023, 05, 02, 16, 00, 00);
            var datetime2 = new DateTime(2023, 05, 02, 16, 15, 00);
            //Time of visit for any Patient is minimom 30 minuts

            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = AppointmentServiceFactory.Create(context);
            var appointment1 = new AddAppointmentBuilder().WhitDateTime(datetime1).Builder();
            var appointment2 = AddAppoinmentDTOFactory.Create(datetime2);

            context.Save(appointment1);
            var actual = async () => await sut.SetAppointment(appointment2);

            await actual.Should().ThrowAsync<TimeConflictedSetAppointmentException>();
        }

        [Fact]
        public async Task CancelAppointment_Cancel_Appointment_Properly()
        {
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = AppointmentServiceFactory.Create(context);
            var appointment1 = new AddAppointmentBuilder().Builder();
            context.Save(appointment1);

            await sut.CancellAppointment(1);
            var actual =await readContext.Appoinments.FirstOrDefaultAsync();

            actual.Should().BeNull();
        }
    }
}
