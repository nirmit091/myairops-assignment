using System;

namespace RegistrationApi.RequestModel
{
    public class Registration_Dto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
