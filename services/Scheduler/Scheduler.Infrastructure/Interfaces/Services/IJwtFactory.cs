using Scheduler.Infrastructure.Dto;
using System.Threading.Tasks;

namespace Scheduler.Infrastructure.Interfaces
{
    public interface IJwtFactory
    {
        Task<Schedule> GenerateEncodedToken(string id, string userName);
    }
}
