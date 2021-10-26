using Templates.Infrastructure.Dto;

namespace Templates.Infrastructure.Responses
{
    public class TemplateResponse
    {
        public Template Template { get; }

        public TemplateResponse(Domain.Entities.Template template)
        {
            Template = new Template(template.Id, template.Start, template.End, template.Position);
        }
    }
}
