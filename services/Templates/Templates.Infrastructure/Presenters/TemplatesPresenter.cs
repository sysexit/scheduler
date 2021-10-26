using Templates.Domain.Interfaces;
using Templates.Infrastructure.Responses;

namespace Templates.Infrastructure.Presenters
{
    public sealed class TemplatesPresenter : IOutputPort<TemplatesResponse>
    {
        public TemplatesResponse data { get; set; }

        public void Handle(TemplatesResponse response)
        {
            data = response;
        }
    }
}
