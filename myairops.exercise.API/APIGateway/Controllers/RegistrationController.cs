using APIGateway.RequestModel;
using APIGateway.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace APIGateway.Controllers
{
    [Route("api/registration")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registerService;

        public RegistrationController(IRegistrationService registerService)
        {
            _registerService = registerService;
        }

        /// <summary>
        /// Used to load registration data to text file
        /// </summary>
        /// <param name="registration_Dto">Request model</param>
        /// <returns>Sucessfully Added or not</returns>
        [HttpPost]
        public ActionResult<bool> GenerateRegistrationData(Registration_Dto registration_Dto)
        {
            return _registerService.GenerateRegistrationData(registration_Dto);
        }
    }
}

