
using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Persistance.EF;
using DoctorAppointment.Persistance.EF.Doctors;
using DoctorAppointment.Persistence.EF;
using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Doctors.Exeptipn;
using DoctorAppointment.Services.Exeptipn;
using DoctorAppointment.Test.Tools.Infrastructure.DatabaseConfig.Unit;
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
        var dto = new AddDoctorDto
        {
            FirstName = "dummy-first-name",
            LastName = "dummy-last-name",
            Field = "heart",
            NationalCode = "2280909952",
        };
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));

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
        var dto1 = new AddDoctorDto
        {
            FirstName = "dummy-first-name1",
            LastName = "dummy-last-name1",
            Field = "heart1",
            NationalCode= "2280909952",
        };
        var dto2 = new AddDoctorDto
        {
            FirstName = "dummy-first-name2",
            LastName = "dummy-last-name2",
            Field = "heart2",
            NationalCode = "2280909952",
        };
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));

        //act
        await sut.Add(dto1);
        var action2=async ()=>await sut.Add(dto2);

        //assert
        var actual3 = readContext.Doctors.First();
        actual3.FirstName.Should().Be(dto1.FirstName);
        actual3.LastName.Should().Be(dto1.LastName);
        actual3.Field.Should().Be(dto1.Field);
        await action2.Should().ThrowAsync<DuplicateNationalCodeException>();
    }

        [Fact]
    public async Task Update_updates_doctor_properly()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        //arrange
        var doctor = new Doctor("dummy-first-name", "dummy-last-name", "heart","2280909952");
        context.Save(doctor);
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));
        var updateDto = new UpdateDoctorDto
        {
            FirstName = "updated-dummy-first-name",
            LastName = "updated-dummy-last-name",
            Field = "child",
            NationalCode="1819586612"
        };
        
        //act
        await sut.Update(doctor.Id, updateDto);
        
        //assert
        var actual = readContext.Doctors.First(_=>_.Id == doctor.Id);
        actual.FirstName.Should().Be(updateDto.FirstName);
        actual.LastName.Should().Be(updateDto.LastName);
        actual.Field.Should().Be(updateDto.Field);
    }

    [Fact]
    public async Task Update_updates_doctor_Throw_DoctorNotFoundException()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        //arrange
        var doctor = new Doctor("dummy-first-name", "dummy-last-name", "heart", "2280909952");
        context.Save(doctor);
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));
        var updateDto = new UpdateDoctorDto
        {
            FirstName = "updated-dummy-first-name",
            LastName = "updated-dummy-last-name",
            Field = "child",
            NationalCode = "1819586612"
        };

        //act
       var action =()=>  sut.Update(3, updateDto);

        //assert
     
       await action.Should().ThrowAsync<DoctorNotFoundException>();

    }
    [Fact]
    public async Task GetAll_GetAll_doctors_Numbers_Should_be_Two()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        //arrange
        var doctor1 = new Doctor("dummy-first-name1", "dummy-last-name1", "heart", "2280909952");
        var doctor2 = new Doctor("dummy-first-name2", "dummy-last-name2", "child", "1812596122");
        context.Save(doctor1);
        context.Save(doctor2);
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));

        //act
        var doctors = await sut.GetAll();

        //assert
        doctors.Count().Should().Be(2);
    }

    [Fact]
    public async Task GetAll_GetAll_doctors_Numbers_Should_Uploaded_Properly()
    {
        var db = new EFInMemoryDatabase();
        var context = db.CreateDataContext<EFDataContext>();
        var readContext = db.CreateDataContext<EFDataContext>();
        //arrange
        var doctor1 = new Doctor("dummy-first-name1", "dummy-last-name1", "heart", "2280909952");
        var doctor2 = new Doctor("dummy-first-name2", "dummy-last-name2", "child", "1812596122");
        context.Save(doctor1);
        context.Save(doctor2);
        var sut = new DoctorAppService(new EFDoctorRepository(context), new EFUnitOfWork(context));

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










