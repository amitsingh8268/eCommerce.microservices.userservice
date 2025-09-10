using eCommerce.Core.DTO;

    namespace eCommerce.Core.ServiceContract;
    public interface IUserService
    {
        public Task<AuthenticationResponse?> Register(RegisterRequest request);

        public Task<AuthenticationResponse?> Login(LoginRequest request);
    }

