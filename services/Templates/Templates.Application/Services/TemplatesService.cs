using Templates.Application.Interfaces;
using Templates.Application.ViewModels;
using Templates.Infrastructure.Interfaces;
using Templates.Infrastructure.Presenters;
using Templates.Infrastructure.Requests;
using Templates.Infrastructure.Responses;
using System;
using System.Threading.Tasks;

namespace Templates.Application.Services
{
    public class TemplatesService : ITemplateService
    {
        private readonly ITemplatesHandler _templateHandler;
        private readonly IAddTemplateHandler _addTemplateHandler;
        private readonly IUpdateTemplateHandler _updateTemplateHandler;
        private readonly IDeleteTemplateHandler _deleteTemplateHandler;
        private readonly TemplatesPresenter _templatesPresenter;
        private readonly TemplatePresenter _templatePresenter;

        public TemplatesService(ITemplatesHandler templateHandler, IAddTemplateHandler addTemplateHandler, IUpdateTemplateHandler updateTemplateHandler, IDeleteTemplateHandler deleteTemplateHandler)
        {
            _templateHandler = templateHandler;
            _addTemplateHandler = addTemplateHandler;
            _updateTemplateHandler = updateTemplateHandler;
            _deleteTemplateHandler = deleteTemplateHandler;
            _templatesPresenter = new TemplatesPresenter();
            _templatePresenter = new TemplatePresenter();
        }

        public async Task<TemplatesResponse> GetTemplates()
        {
            await _templateHandler.Handle(_templatesPresenter);
            return _templatesPresenter.data;
        }

        public async Task<TemplateResponse> AddTemplate(AddTemplateViewModel model)
        {
            await _addTemplateHandler.Handle(new TemplatesRequest(model.Start, model.End, model.Position), _templatePresenter);
            return _templatePresenter.data;
        }

        public async Task<TemplateResponse> UpdateTemplate(UpdateTemplateViewModel model)
        {
            await _updateTemplateHandler.Handle(new TemplatesRequest(model.Id, model.Start, model.End, model.Position), _templatePresenter);
            return _templatePresenter.data;
        }

        public async Task DeleteTemplate(int id)
        {
            await _deleteTemplateHandler.Handle(new TemplatesRequest(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
