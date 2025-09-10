using eCommerce.Core.SecurityContract;
using BC = BCrypt.Net.BCrypt;   

namespace eCommerce.Infrastructure.Security;

public class BCryptPasswordHasher : IPasswordHasher
{
    public string GeneratePassword(string password)
    {
       return BC.HashPassword(password);
    }

    public bool VerifyPassword(string hashedPassword, string password)
    {
       return BC.Verify(password, hashedPassword);
    }
}

