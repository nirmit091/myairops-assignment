using APIGateway.Services.Interfaces;
using APIGateway.Util;
using APIGateway.RequestModel;

namespace APIGateway.Services
{
    public class RegistrationService : IRegistrationService
    {
        /// <summary>
        /// Used to load registration data to text file
        /// </summary>
        /// <param name="registration_Dto">Request model</param>
        /// <returns>Sucessfully Added or not</returns>
        public bool GenerateRegistrationData(Registration_Dto registration_Dto)
        {
            var objHttpProxyUtility = new HttpProxyUtility();
            return objHttpProxyUtility.ProcessRestRequest<bool>(new RestRequestParameters { RequestUrl = $"{Constants.REGISTRATIONAPI}", PostData = registration_Dto });
        }
    }
}
