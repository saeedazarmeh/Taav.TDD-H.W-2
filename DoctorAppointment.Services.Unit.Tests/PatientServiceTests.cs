
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors.Exeptipn;
using DoctorAppointment.Services.Patients.Exeptipn;
using DoctorAppointment.Test.Tools.Infrastructure.Builder.Patients;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using DoctorAppointment.Test.Tools.Infrastructure.Facrory.Patients;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientAppointment.Services.Unit.Tests
{
    public class PatientServiceTests
    {
        [Fact]
        public async Task Add_adds_a_new_Patient_properly()
        {
            //arrange
            var dto = AddPatientDTOFactory.Create();
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = PatientServiceFactory.Create(context);

            //act
            await sut.Add(dto);

            //assert
            var actual = readContext.Patients.Single();
            actual.FirstName.Should().Be(dto.FirstName);
            actual.LastName.Should().Be(dto.LastName);
            actual.NationalCode.Should().Be(dto.NationalCode);
        }
        [Fact]
        public async Task Add_adds_a_new_Patient_Throw_DuplicateNationalCodeException()
        {
            //arrange
            var nationalCode = "2280909952";
            var Patient = new AddPatientBuilder().Builder();
            var dto2 = AddPatientDTOFactory.Create(nationalCode);
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = PatientServiceFactory.Create(context);

            //act
            context.Save(Patient);
            var action2 = async () => await sut.Add(dto2);

            //assert
            await action2.Should().ThrowAsync<DuplicateNationalCodeException>();
        }

        [Fact]
        public async Task Update_updates_Patient_properly()
        {
            //arrange
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = PatientServiceFactory.Create(context);
            var Patient = new AddPatientBuilder().Builder();
            context.Save(Patient);
            var updateDto = UpdatePatientDTOFactory.Create();

            //act
            await sut.Update(1, updateDto);

            //assert
            var actual = readContext.Patients.First();
            actual.FirstName.Should().Be(updateDto.FirstName);
            actual.LastName.Should().Be(updateDto.LastName);
            actual.NationalCode.Should().Be(updateDto.NationalCode);
        }

        [Fact]
        public async Task Update_updates_Patient_Throw_PatientNotFoundException()
        {
            //arrange
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = PatientServiceFactory.Create(context);
            //var Patient = AddPatientDTOFactory.Create();
            //context.Save(Patient);
            var updateDto = UpdatePatientDTOFactory.Create();

            //act
            var action = () => sut.Update(3, updateDto);

            //assert

            await action.Should().ThrowAsync<PatientNotFoundException>();

        }
        [Fact]
        public async Task GetAll_GetAll_Patients_Numbers_Should_be_Two()
        {
            //arrange
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var sut = PatientServiceFactory.Create(context);
            var Patient1 = new AddPatientBuilder().Builder();
            var Patient2 = new AddPatientBuilder().WithNationalCode("2288994596").Builder();
            context.Save(Patient1);
            context.Save(Patient2);

            //act
            var Patients = await sut.GetAll();

            //assert
            Patients.Count().Should().Be(2);
        }

        [Fact]
        public async Task GetAll_GetAll_Patients_Numbers_Should_Uploaded_Properly()
        {
            //arrange
            var db = new EFInMemoryDatabase();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = PatientServiceFactory.Create(context);
            var Patient1 = new AddPatientBuilder().Builder();
            var Patient2 = new AddPatientBuilder().WithNationalCode("2288994596").Builder();
            context.Save(Patient1);
            context.Save(Patient2);

            //act
            var Patients = await sut.GetAll();

            //assert
            Patients[0].FirstName.Should().Be(Patient1.FirstName);
            Patients[0].LastName.Should().Be(Patient1.LastName);
            Patients[0].NationalCode.Should().Be(Patient1.NationalCode);
            Patients[1].FirstName.Should().Be(Patient2.FirstName);
            Patients[1].LastName.Should().Be(Patient2.LastName);
            Patients[1].NationalCode.Should().Be(Patient2.NationalCode);
        }
    }
}
