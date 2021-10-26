using System;
using Templates.Domain.Commands;

namespace Templates.Infrastructure.Requests
{
    public abstract class TemplateRequest : Command
    {
        public int Id { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public int Position { get; set; }
    }
}
