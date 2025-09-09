namespace eCommerce.Core.SecurityContract;

public interface IPasswordHasher
{
    string GeneratePassword(string password);
    bool VerifyPassword(string hashedPassword, string password);
}

