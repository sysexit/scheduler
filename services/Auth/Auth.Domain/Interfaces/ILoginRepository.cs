using Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {
        Login FindByEmail(string email);
        bool CheckPassword(Login login, string password);
    }
}
