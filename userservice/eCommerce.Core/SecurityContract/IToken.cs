using eCommerce.Core.Entities;

namespace eCommerce.Core.SecurityContract;

public interface IToken
{
    public string CreateAccessToken(ApplicationUser user);
}

