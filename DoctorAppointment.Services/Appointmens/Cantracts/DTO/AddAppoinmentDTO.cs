using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointmens.Cantracts.DTO
{
    public class AddAppoinmentDTO
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime DaTeTime { get; set; }
        public decimal Price { get; set; }
        public decimal Paid { get; set; }
    }
}
