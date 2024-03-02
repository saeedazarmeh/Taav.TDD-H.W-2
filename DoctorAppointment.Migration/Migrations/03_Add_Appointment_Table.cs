using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Migration.Migrations
{
    [Migration(03)]
    public class _03_Add_Appointment_Table:FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Appointments")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("DoctorId").AsInt32()
                .WithColumn("PatientId").AsInt32()
                .WithColumn("Paid").AsDecimal()
                .WithColumn("Price").AsDecimal()
                .WithColumn("DaTeTime").AsDateTime();
            Create.ForeignKey("FK_Appointment_Doctor").FromTable("Appointments").ForeignColumn("DoctorId").ToTable("Doctors").PrimaryColumn("Id");
            Create.ForeignKey("FK_Appointment_Patient").FromTable("Appointments").ForeignColumn("PatientId").ToTable("Patients").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.Table("Appointments");
        }
    }
}
