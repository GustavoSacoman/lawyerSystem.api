using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace lawyerSystem.api.Infrastructure.Configurations;

public class CryptoHelper
{
    public static string GenerateSalt()
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return Convert.ToBase64String(salt);
    }

    public static string HashPassword(string password, string salt)
    {
        byte[] saltBytes = Convert.FromBase64String(salt);

        byte[] hash = KeyDerivation.Pbkdf2(
            password: password,
            salt: saltBytes,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 10000,
            numBytesRequested: 256 / 8);

        return Convert.ToBase64String(hash);
    }

    public static bool VerifyPassword(string password, string storedHash, string storedSalt)
    {
        var hashedPassword = HashPassword(password, storedSalt);
        return hashedPassword == storedHash;
    }
}
