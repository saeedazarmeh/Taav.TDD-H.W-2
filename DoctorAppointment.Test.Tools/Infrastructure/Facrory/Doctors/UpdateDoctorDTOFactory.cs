using DoctorAppointment.Services.Doctors.Contracts.Dto;
using DoctorAppointment.Services.Patients.Contracts.Dto;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Doctors
{
    public class UpdateDoctorDTOFactory
    {
        public static UpdateDoctorDto Create()
        {
            return new UpdateDoctorDto()
            {
                FirstName = "dummy-first-name2",
                LastName = "dummy-last-family2",
                Field = "health",
                NationalCode = "1122558899",
            };
        }
    }
}
