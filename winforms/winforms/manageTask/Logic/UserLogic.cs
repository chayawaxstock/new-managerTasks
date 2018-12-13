using System.Text;

namespace manageTask.Logic
{
    public class UserLogic
    {
        /// <summary>
        /// PasswordToSHA
        /// </summary>
        /// <param name="password">password</param>
        /// <returns>password -sha 256</returns>
        public static string PasswordToSHA(string password)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            string newPassword = hash.ToString();
            return newPassword.ToLower();
        }
    }
}
