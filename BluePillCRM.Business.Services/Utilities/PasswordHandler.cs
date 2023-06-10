using BCrypt.Net;


namespace BluePillCRM.Business.Services.Utilities
{
    public class PasswordHandler
    {
        public static string HashPassword(string password)
        {
            // Generate a random salt value
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            // Hash the password using bcrypt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the provided password against the stored hashed password
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
