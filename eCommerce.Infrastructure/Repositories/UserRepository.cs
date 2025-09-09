using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Core.SecurityContract;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _context;
        private readonly IPasswordHasher _hasher;

        public UserRepository(DapperDbContext context, IPasswordHasher hasher )
        {
            _context = context;
            _hasher = hasher;
    }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.userId = Guid.NewGuid();
            string query = "insert into public.\"Users\" (\"UserId\", \"FirstName\",\"LastName\",\"Email\",\"Password\",\"Gender\") " +
            "values(@UserId,@firstName,@lastName,@email,@password,@gender)";
            user.Password = _hasher.GeneratePassword(user.Password);
            
            int rowEffected = await _context.DbConnection.ExecuteAsync(query, user);
            if (rowEffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
        {
             string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email";
             var param = new { Email = email};
            
            ApplicationUser? user  = await _context.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, param);
            if(user != null && _hasher.VerifyPassword(user.Password, password))
            {
                return user;
            }
            return null;
        }
    }

