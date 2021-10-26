using Users.Domain.Entities;

namespace Users.Domain.Interfaces
{
    public interface ILoginRepository : IRepository<Login>
    {
        Login FindByEmail(string email);
    }
}
