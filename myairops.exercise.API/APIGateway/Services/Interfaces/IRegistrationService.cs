using APIGateway.RequestModel;

namespace APIGateway.Services.Interfaces
{
    public interface IRegistrationService
    {
        /// <summary>
        /// Used to load registration data to text file
        /// </summary>
        /// <param name="registration_Dto">Request model</param>
        /// <returns>Sucessfully Added or not</returns>
        bool GenerateRegistrationData(Registration_Dto registration_Dto);
    }
}
