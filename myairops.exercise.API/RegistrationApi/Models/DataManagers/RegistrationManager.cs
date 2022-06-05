using System;
using System.IO;
using System.Text;
using RegistrationApi.Models.Repositories;
using RegistrationApi.RequestModel;

namespace RegistrationApi.Models.DataManagers
{
    public class RegistrationManager : IRegistrationRepository
    {
        /// <summary>
        /// Used to load registration data to text file
        /// </summary>
        /// <param name="registration_Dto">Request model</param>
        /// <returns>Sucessfully Added or not</returns>
        public bool GenerateRegistrationData(Registration_Dto registration_Dto)
        {
            StringBuilder registerationData = new StringBuilder();
            string path = string.Format(AppDomain.CurrentDomain.BaseDirectory + "/register.txt");
            if (registration_Dto != null) 
            {
                registerationData.AppendLine("Id : " + registration_Dto.Id);
                registerationData.AppendLine("UserName : " + registration_Dto.UserName);
                registerationData.AppendLine("Email : " + registration_Dto.EmailId);
                registerationData.AppendLine("DateOfBirth : " + registration_Dto.DateOfBirth);
                registerationData.AppendLine("----------------------------------------------");

                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(registerationData);
                    }
                }
                else 
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(registerationData);
                    }
                }

                return true;
            }
            
            return false;
        }
    }
}
