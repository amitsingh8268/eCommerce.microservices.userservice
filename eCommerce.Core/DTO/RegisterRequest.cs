using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.DTO
{
    public record RegisterRequest(string? firstName, string? lastName, string? email, string password, GenderOptions gender);
}
