namespace eCommerce.Core.DTO
{
    public record AuthenticationResponse(Guid UserId, string? Email, string? FirstName, string? LastName, string genderption, string? refreshToken, string? token);
    
}
