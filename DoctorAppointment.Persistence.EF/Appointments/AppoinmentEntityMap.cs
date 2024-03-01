using DoctorAppointment.Entities.Appoinments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistance.EF.Appointments
{
    public class AppoinmentEntityMap : IEntityTypeConfiguration<Appoinment>
    {
        public void Configure(EntityTypeBuilder<Appoinment> builder)
        {
            builder.HasKey(_ => _.Id);
            builder.Property(_ => _.Id).ValueGeneratedOnAdd();
            builder.Property(_ => _.DoctorId).IsRequired();
            builder.Property(_ => _.PatientId).IsRequired();
            builder.Property(_ => _.Price).IsRequired();
            builder.Property(_ => _.Paid).IsRequired();
        }
    }
}
