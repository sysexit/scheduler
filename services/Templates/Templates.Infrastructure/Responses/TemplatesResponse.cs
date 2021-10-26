using Templates.Infrastructure.Dto;
using System.Collections.Generic;

namespace Templates.Infrastructure.Responses
{
    public class TemplatesResponse
    {
        public List<Template> Templates { get; }

        public TemplatesResponse(List<Template> timesheets)
        {
            Templates = timesheets;
        }

        public TemplatesResponse(List<Domain.Entities.Template> templates)
        {
            List<Template> templateList = new List<Template>();
            foreach (Domain.Entities.Template template in templates) {
                var t = new Template(template.Id, template.Start, template.End, template.Position);
                templateList.Add(t);
            }
            Templates = templateList;
        }

        public TemplatesResponse(Domain.Entities.Template template)
        {
            List<Template> templateList = new List<Template>();
            var t = new Template(template.Id, template.Start, template.End, template.Position);
            templateList.Add(t);
            Templates = templateList;
        }
    }
}
