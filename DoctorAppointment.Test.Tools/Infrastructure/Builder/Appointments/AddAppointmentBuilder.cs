using DoctorAppointment.Entities.Appoinments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Builder.Appointments
{
    public class AddAppointmentBuilder
    {
       private readonly Appoinment _appoinment;

        public AddAppointmentBuilder()
        {
            _appoinment = new Appoinment(1,1, new DateTime(2023, 03, 12, 18, 00, 00),200000,200000);
        }

        public AddAppointmentBuilder WhitDateTime(DateTime dateTime)
        {
            _appoinment.Edit(dateTime);
            return this;
        }

        public Appoinment Builder()
        {
            return _appoinment;
        }
    }
}
