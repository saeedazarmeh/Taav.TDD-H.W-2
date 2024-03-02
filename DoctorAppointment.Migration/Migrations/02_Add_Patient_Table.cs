using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Migration.Migrations
{
    [Migration(02)]
    public class _02_Add_Patient_Table:FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Patients")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(20)
                .WithColumn("LastName").AsString(40)
                .WithColumn("NationalCode").AsString(10);
        }

        public override void Down()
        {
            Delete.Table("Patients");
        }
    }
}
