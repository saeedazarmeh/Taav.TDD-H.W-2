using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Migration.Migrations
{
    [Migration(01)]
    public class _01_Add_Doctor_Table : FluentMigrator.Migration
    {
        public override void Up()
        {
            Create.Table("Doctors")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("FirstName").AsString(20)
                .WithColumn("LastName").AsString(40)
                .WithColumn("Field").AsString(60)
                .WithColumn("NationalCode").AsString(10);
        }

        public override void Down()
        {
            Delete.Table("Doctors");
        }

       
    }
}
