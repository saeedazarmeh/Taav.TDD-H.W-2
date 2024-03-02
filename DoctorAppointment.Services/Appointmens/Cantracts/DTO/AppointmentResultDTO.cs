using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appointmens.Cantracts.DTO
{
    public class AppointmentResultDTO
    {
        public int AppointmentId { get; set; }
        public string Patient { get; set; }
        public string Doctor { get; set; }
        public DateTime DaTeTime { get; set; }
        public decimal Price { get; set; }
        public decimal Paid { get; set; }
    }
}
