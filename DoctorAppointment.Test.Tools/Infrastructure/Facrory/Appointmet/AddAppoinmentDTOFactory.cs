using DoctorAppointment.Services.Appointmens.Cantracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Appointmet
{
    public class AddAppoinmentDTOFactory
    {
        public static AddAppoinmentDTO Create()
        {
            return new AddAppoinmentDTO()
            {
                PatientId = 1,
                DoctorId = 1,
                DaTeTime = new DateTime(2023, 03, 12, 18, 00, 00),
                Price = 20000,
                Paid = 20000,
            };
        }
    }
}
