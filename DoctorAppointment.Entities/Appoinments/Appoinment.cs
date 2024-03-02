using DoctorAppointment.Entities.Doctors;
using DoctorAppointment.Entities.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Entities.Appoinments
{
    public class Appoinment
    {
        public Appoinment(int patientId, int doctorId, DateTime daTeTime, decimal price, decimal paid)
        {
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.DaTeTime = daTeTime;
            this.Price = price;
            this.Paid = paid;
        }
        public int Id { get; private set; }
        public int PatientId { get; private set; }
        public int DoctorId { get; private set; }
        public DateTime DaTeTime { get; private set; }
        public decimal Price { get; private set; }
        public decimal Paid { get; private set; }
        public Patient Patient { get; private set; }
        public Doctor Doctor { get; private set; }

        public void Edit( DateTime daTeTime)
        {
            if (daTeTime != null)
            {
                this.DaTeTime = daTeTime;
            }

        }

    }
}
