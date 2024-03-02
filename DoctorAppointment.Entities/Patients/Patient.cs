using DoctorAppointment.Entities.Appoinments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Entities.Patients
{
    public class Patient
    {
        public Patient(string firstName, string lastName, string nationalCode)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
        }

        public int Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NationalCode { get; private set; }
        public List<Appoinment> Appoinments { get; private set; }

        public void Edit(string? firstName = null, string? lastName = null,  string? nationalCode = null)
        {
            if (firstName != null)
            {
                FirstName = firstName;
            }
            if (lastName != null)
            {
                LastName = lastName;
            }
            if (nationalCode != null)
            {
                NationalCode = nationalCode;
            }

        }
    }
}
