using eCommerce.Core.Entities;
using eCommerce.Core.SecurityContract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eCommerce.Infrastructure.Security;

public class JwtTokenService : IToken
{
    private readonly IConfiguration _configuration;
    public JwtTokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string CreateAccessToken(ApplicationUser user)
    {
        var jwt = _configuration.GetSection("JWT");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["key"]));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim> {
        new Claim(JwtRegisteredClaimNames.Sub, user.userId.ToString()),
        new Claim(ClaimTypes.Name, user.Email)};
        var expires = DateTime.UtcNow.AddMinutes(double.Parse(jwt["AccessTokenExpirationMinutes"]));
        var token = new JwtSecurityToken(jwt["Issuer"], jwt["Audience"], claims, expires: expires, signingCredentials: cred);
        return new JwtSecurityTokenHandler().WriteToken(token);

    }
}

