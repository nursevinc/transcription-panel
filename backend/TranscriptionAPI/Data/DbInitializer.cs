using System.Security.Cryptography;
using System.Text;
using TranscriptionAPI.Model;

namespace TranscriptionAPI.Data
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var admin = new User
                {
                    Username = "admin",
                    PasswordHash = HashPassword("1234"),
                    Role = "admin"
                };

                context.Users.Add(admin);
                context.SaveChanges();
            }
            if (!context.Audios.Any())
            {
                context.Audios.AddRange(
                    new Audio { FileName = "ornek1.mp3", FilePath = "/NewFolder1/ornek1.mp3" }
                   // new Audio { FileName = "ornek2.wav", FilePath = "/files/ornek2.wav" }
                );

                context.SaveChanges();
            }
        }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}

