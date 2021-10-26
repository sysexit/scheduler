using Templates.Application.ViewModels;
using Templates.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Templates.Application.Interfaces
{
    public interface ITemplateService : IDisposable
    {
        Task<TemplatesResponse> GetTemplates();
        Task<TemplateResponse> AddTemplate(AddTemplateViewModel model);
        Task<TemplateResponse> UpdateTemplate(UpdateTemplateViewModel model);
        Task DeleteTemplate(int id);
    }
}
