using Users.Domain.Dto;
using System.Collections.Generic;

namespace Users.Infrastructure.Responses
{
    public class UsersResponse
    {
        public IEnumerable<User> Users { get; }

        public UsersResponse(IEnumerable<User> users)
        {
            Users = users;
        }

        public UsersResponse(IEnumerable<Domain.Entities.User> users)
        {
            List<User> userList = new List<User>();
            foreach (Domain.Entities.User u in users) {
                var dtoUser = new User(u.Id, u.Email, u.First, u.Last, u.Positions, u.Display);
                userList.Add(dtoUser);
            }
            Users = userList;
        }

        public UsersResponse(Domain.Entities.User user)
        {
            List<User> userList = new List<User>();
            var dtoUser = new User(user.Id, user.Email, user.First, user.Last, user.Positions, user.Display);
            userList.Add(dtoUser);
            Users = userList;
        }
    }
}
