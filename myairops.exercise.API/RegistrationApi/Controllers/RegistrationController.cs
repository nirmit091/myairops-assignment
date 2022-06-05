using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Models.Repositories;
using RegistrationApi.RequestModel;

namespace RegistrationApi.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationRepository _registrationRepository;

        public RegistrationController(IRegistrationRepository registrationRepository)
        {
            _registrationRepository = registrationRepository;
        }

        /// <summary>
        /// Used to load registration data to text file
        /// </summary>
        /// <param name="registration_Dto">Request model</param>
        /// <returns>Sucessfully Added or not</returns>
        [HttpPost]
        public ActionResult<bool> GenerateRegistrationData(Registration_Dto registration_Dto)
        {
            return _registrationRepository.GenerateRegistrationData(registration_Dto);
        }
    }
}
