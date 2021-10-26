using Timesheets.Infrastructure.Dto;
using System.Threading.Tasks;

namespace Timesheets.Infrastructure.Interfaces
{
    public interface IJwtFactory
    {
        Task<Timesheet> GenerateEncodedToken(string id, string userName);
    }
}
