using System;
using Templates.Infrastructure.Validators;

namespace Templates.Infrastructure.Requests
{
    public class TemplatesRequest : TemplateRequest
    {
        public TemplatesRequest()
        {
        }

        public TemplatesRequest(int id)
        {
            Id = id;
        }

        public TemplatesRequest(int id, string start, string end, int position)
        {
            Id = id;
            Start = start;
            End = end;
            Position = position;
        }

        public TemplatesRequest(string start, string end, int position)
        {
            Start = start;
            End = end;
            Position = position;
        }

        public override bool IsValid()
        {
            ValidationResult = new TemplatesRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
