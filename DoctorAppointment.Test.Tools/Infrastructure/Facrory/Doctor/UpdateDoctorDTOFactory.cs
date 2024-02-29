using DoctorAppointment.Services.Doctors.Contracts.Dto;

namespace DoctorAppointment.Test.Tools.Infrastructure.Facrory.Doctor
{
    public class UpdateDoctorDTOFactory
    {
        public static UpdateDoctorDto Create()
        {
            return new UpdateDoctorDto()
            {
                FirstName = "dummy-first-name1",
                LastName = "dummy-last-family1",
                Field ="health",
                NationalCode = "1122558899",
            };
        }
    }
}
