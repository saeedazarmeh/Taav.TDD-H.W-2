
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Doctors.Exeptipn;
using DoctorAppointment.Services.Exeptipn;
using DoctorAppointment.Test.Tools.Infrastructure.Builder;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
using DoctorAppointment.Test.Tools.Infrastructure.Facrory.Doctor;
using DoctorAppointment.Test.Tools.Infrastructure.Facrory.InmemoryDatabase;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using System.Numerics;

namespace DoctorAppointment.Services.Unit.Tests;

public class DoctorServiceTests
{
    [Fact]
    public async Task Add_adds_a_new_doctor_properly()
    {
        //arrange
        var dto = AddDoctorDTOFactory.Create();
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var sut = DoctorService.Create(context);

        //act
        await sut.Add(dto);

        //assert
        var actual = readContext.Doctors.Single();
        actual.FirstName.Should().Be(dto.FirstName);
        actual.LastName.Should().Be(dto.LastName);
        actual.Field.Should().Be(dto.Field);
    }
    [Fact]
    public async Task Add_adds_a_new_doctor_Throw_DuplicateNationalCodeException()
    {
        //arrange
        var nationalCode = "2280909952";
        var doctor = new AddDoctorBuilder().Builder();
        var dto2 = AddDoctorDTOFactory.Create(nationalCode);
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var sut = DoctorService.Create(context);

        //act
        context.Save(doctor);
        var action2=async ()=>await sut.Add(dto2);

        //assert
        await action2.Should().ThrowAsync<DuplicateNationalCodeException>();
    }

        [Fact]
    public async Task Update_updates_doctor_properly()
    {
        //arrange
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var sut = DoctorService.Create(context);
        var doctor = new AddDoctorBuilder().Builder();
        context.Save(doctor);
        var updateDto = UpdateDoctorDTOFactory.Create();
        var id=readContext.Doctors.First().Id;
        
        //act
        await sut.Update(id, updateDto);
        
        //assert
        var actual = readContext.Doctors.First(_=>_.Id == id);
        actual.FirstName.Should().Be(updateDto.FirstName);
        actual.LastName.Should().Be(updateDto.LastName);
        actual.Field.Should().Be(updateDto.Field);
    }

    [Fact]
    public async Task Update_updates_doctor_Throw_DoctorNotFoundException()
    {
        //arrange
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var sut = DoctorService.Create(context);
        //var doctor = AddDoctorDTOFactory.Create();
        //context.Save(doctor);
        var updateDto = UpdateDoctorDTOFactory.Create();

        //act
       var action =()=>  sut.Update(3, updateDto);

        //assert
     
       await action.Should().ThrowAsync<DoctorNotFoundException>();

    }
    [Fact]
    public async Task GetAll_GetAll_doctors_Numbers_Should_be_Two()
    {
        //arrange
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var sut = DoctorService.Create(context);
        var doctor1 = new AddDoctorBuilder().Builder();
        var doctor2 = new AddDoctorBuilder().WithNationalCode("2288994596").Builder();
        context.Save(doctor1);
        context.Save(doctor2);

        //act
        var doctors = await sut.GetAll();

        //assert
        doctors.Count().Should().Be(2);
    }

    [Fact]
    public async Task GetAll_GetAll_doctors_Numbers_Should_Uploaded_Properly()
    {
        //arrange
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var sut = DoctorService.Create(context);
        var doctor1 = new AddDoctorBuilder().Builder();
        var doctor2 = new AddDoctorBuilder().WithNationalCode("2288994596").Builder();
        context.Save(doctor1);
        context.Save(doctor2);

        //act
        var doctors = await sut.GetAll();

        //assert
        doctors[0].FirstName.Should().Be(doctor1.FirstName);
        doctors[0].LastName.Should().Be(doctor1.LastName);
        doctors[0].Field.Should().Be(doctor1.Field);
        doctors[1].FirstName.Should().Be(doctor2.FirstName);
        doctors[1].LastName.Should().Be(doctor2.LastName);
        doctors[1].Field.Should().Be(doctor2.Field);
    }
}










