using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.ServiceContract;

namespace eCommerce.Core.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResponse?> Login(LoginRequest request)
        {
           var user = await _userRepository.GetUserByEmailAndPassword(request.email, request.password);
            if(user is null)
            {
                return null;
            }
            return new AuthenticationResponse(user.userId, user.Email, user.FirstName, user.LastName, user.Gender, "refresh token", "access token");
        }

        public async Task<AuthenticationResponse?> Register(RegisterRequest request)
        {
            ApplicationUser user = new ApplicationUser()
            {
                FirstName = request.firstName,
                LastName = request.lastName,
                Email = request.email,
                Password = request.password,
                Gender = request.gender.ToString()
            };
            var registerUser = await _userRepository.AddUser(user);
            if (registerUser is null)
            {
                return null;
            }
            return new AuthenticationResponse(registerUser.userId, registerUser.Email, registerUser.FirstName, registerUser.LastName, registerUser.Gender, "refresh token", "access token");
        }
    }
}
