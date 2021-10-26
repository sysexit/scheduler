using Microsoft.AspNetCore.Mvc;
using NodaTime;
using System;
using System.ComponentModel.DataAnnotations;

namespace Scheduler.Application.ViewModels
{
    public class PublishScheduleViewModel
    {
        [FromBody]
        [Required]
        public Instant Start { get; set; }

        [FromBody]
        [Required]
        public Instant End { get; set; }
    }
}
