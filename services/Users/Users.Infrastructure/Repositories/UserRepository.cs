using Users.Domain.Entities;
using Users.Domain.Interfaces;
using Users.Infrastructure.Context;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Users.Infrastructure.Helpers;
using System;
using Microsoft.EntityFrameworkCore;

namespace Users.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUsersRepository
    {
        private readonly UsersContext _context;

        public UserRepository(UsersContext authContext) : base(authContext)
        {
            _context = authContext;
        }

        public User FindById(int id)
        {
            return _context.Users.FirstOrDefault(l => l.Id == id);
        }

        public Domain.Dto.User DtoUserById(int id)
        {
            var user = FindById(id);
            var User = _context.Logins.FirstOrDefault(l => l.Email == user.Email);
            return new Domain.Dto.User(user.Id, user.Email, user.First, user.Last, user.Positions, user.Display, User.Group, User.Enabled);
        }

        public User FindByEmail(string email)
        {
            return _context.Users.FirstOrDefault(l => l.Email == email);
        }

        public Task<List<Domain.Dto.User>> FindAllUsersAsync()
        {
            return (from u in _context.Users
                    join l in _context.Logins on u.Email equals l.Email into lins
                    from login in lins.DefaultIfEmpty()
                    orderby u.First
                    select new Domain.Dto.User(u.Id, u.Email, u.First, u.Last, u.Positions, u.Display,
                    login.Group == null ? 1 : login.Group, login.Enabled == null ? false : login.Enabled)) // brilliant
                         .ToListAsync();
        }

        public Task<List<User>> FindEnabledUsersAsync()
        {
            return (from u in _context.Users
                    where (from l in _context.Logins where l.Enabled == true select l.Email).Contains(u.Email)
                    select u)
                .ToListAsync();
        }

        public Task<List<Domain.Dto.User>> FindScheduleUsersAsync()
        {
            return (from u in _context.Users
                    join l in _context.Logins on u.Email equals l.Email into lins
                    from login in lins.DefaultIfEmpty()
                    where (login.Enabled == true && login.Group == int.Parse(Constants.Strings.JwtClaims.Staff) || login.Enabled == null)
                    orderby u.First
                    select new Domain.Dto.User(u.Id, u.Email, u.First, u.Last, u.Positions, u.Display,
                     login.Group == null ? 1 : login.Group, login.Enabled == null ? false : login.Enabled)

                    ) // brilliant
                .ToListAsync();
        }
    }
}
