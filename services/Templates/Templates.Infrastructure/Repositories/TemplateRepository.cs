using Templates.Domain.Entities;
using Templates.Domain.Interfaces;
using Templates.Infrastructure.Context;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Templates.Infrastructure.Repositories
{
    public class TemplateRepository : Repository<Template>, ITemplateRepository
    {
        private readonly TemplatesContext _context;

        public TemplateRepository(TemplatesContext authContext) : base(authContext)
        {
            _context = authContext;
        }

        public Task<Template> FindByIdAsync(int id)
        {
            return _context.Templates.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
