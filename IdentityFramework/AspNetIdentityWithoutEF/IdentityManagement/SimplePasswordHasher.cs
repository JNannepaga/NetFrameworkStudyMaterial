using Microsoft.AspNet.Identity;
using System;
using System.Text;

namespace IdentityOwinIntegrationWithoutEF.IdentityManagement
{
    public class SimplePasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(password);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(providedPassword))
                return PasswordVerificationResult.Success;

            byte[] base64EncodedBytes = System.Convert.FromBase64String(hashedPassword);
            string decodedPassword = Encoding.UTF8.GetString(base64EncodedBytes);

            bool isValid = decodedPassword.Equals(providedPassword, StringComparison.OrdinalIgnoreCase);
            
            if (isValid)
                return PasswordVerificationResult.Success;

            return PasswordVerificationResult.Failed;
        }
    }
}