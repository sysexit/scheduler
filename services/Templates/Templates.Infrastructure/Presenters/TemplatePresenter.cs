using Templates.Domain.Interfaces;
using Templates.Infrastructure.Responses;

namespace Templates.Infrastructure.Presenters
{
    public sealed class TemplatePresenter : IOutputPort<TemplateResponse>
    {
        public TemplateResponse data { get; set; }

        public void Handle(TemplateResponse response)
        {
            data = response;
        }
    }
}
