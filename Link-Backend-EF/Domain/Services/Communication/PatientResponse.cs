using Link_Backend_EF.Domain.Models;

namespace Link_Backend_EF.Domain.Services.Communication
{
    public class PatientResponse : BaseResponse<Patient>
    {
        public PatientResponse(string message) : base(message)
        {
        }

        public PatientResponse(Patient resource) : base(resource)
        {
        }
    }
}
