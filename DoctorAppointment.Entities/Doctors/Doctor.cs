using DoctorAppointment.Entities.Appoinments;

namespace DoctorAppointment.Entities.Doctors;

public class Doctor
{
    public Doctor(string firstName, string lastName, string field, string nationalCode)
    {
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        Field = field;
    }

    public int Id { get;private set; }
    public string FirstName { get;private set; }
    public string LastName { get;private set; }
    public string NationalCode { get;private set; }
    public string Field { get;private set; }
    public List<Appoinment> Appoinments { get;private set; }

    public void Edit(string? firstName=null, string? lastName = null, string? field=null, string? nationalCode=null)
    {
        if (firstName != null)
        {
            FirstName = firstName;
        }
        if (lastName != null)
        {
            LastName = lastName;
        }
        if (field != null)
        {
            Field = field;
        }
        if (nationalCode != null)
        {
            NationalCode = nationalCode;
        }
   
    }
}
