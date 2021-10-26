using Templates.Infrastructure.Requests;

namespace Templates.Infrastructure.Validators
{
    public class TemplatesRequestValidation : TemplateValidation<TemplatesRequest>
    {
        public TemplatesRequestValidation()
        {
            ValidateDateTimes();
        }
    }
}
