using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
namespace WebApplication1.Models.Domain
{
    public class Passwordhasher
    {
        public static void Main(string[] args)
        {
            string sharedAmendmentPassword = "jobmend123"; // <--- CHANGE THIS!
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(sharedAmendmentPassword);
            Console.WriteLine("Generated Hash: " + hashedPassword);
            // Copy this hash!
        }
    }
}
