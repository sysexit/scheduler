using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.Application.ViewModels
{
    public class AddTimesheetViewModel
    {
        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
