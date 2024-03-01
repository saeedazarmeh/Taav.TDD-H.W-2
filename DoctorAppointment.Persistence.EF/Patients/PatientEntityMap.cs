using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Entities.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorAppointment.Persistance.EF.Doctors;

public class PatientEntityMap : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Id).ValueGeneratedOnAdd();
        builder.Property(_ => _.FirstName).IsRequired();
        builder.Property(_ => _.LastName).IsRequired();
    }
}