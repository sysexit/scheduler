using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Templates.Domain.Entities;

namespace Templates.Domain.Interfaces
{
    public interface ITemplateRepository : IRepository<Template>
    {
        Task<Template> FindByIdAsync(int id);
    }
}
