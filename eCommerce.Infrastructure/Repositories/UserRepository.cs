using Dapper;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoryContract;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories;

    internal class UserRepository : IUserRepository
    {
        private readonly DapperDbContext _context;
        public UserRepository(DapperDbContext context )
        {
            _context = context;
        }

        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.userId = Guid.NewGuid();
            string query = "insert into public.\"Users\" (\"UserId\", \"FirstName\",\"LastName\",\"Email\",\"Password\",\"Gender\") " +
            "values(@UserId,@firstName,@lastName,@email,@password,@gender)";
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
            string query = "SELECT * FROM public.\"Users\" WHERE \"Email\"=@Email AND \"Password\"=@Password";
             var param = new { Email = email, Password = password };
            
            ApplicationUser? user  = await _context.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(query, param);
            return user;
        }
    }

