using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Domain.Entities;

namespace Users.Domain.Interfaces
{
    public interface IUsersRepository : IRepository<User>
    {
        public User FindByEmail(string email);
        public User FindById(int id);
        public Domain.Dto.User DtoUserById(int id);
        Task<List<Domain.Dto.User>> FindAllUsersAsync();
        Task<List<Domain.Dto.User>> FindScheduleUsersAsync();
        Task<List<User>> FindEnabledUsersAsync();
    }
}
