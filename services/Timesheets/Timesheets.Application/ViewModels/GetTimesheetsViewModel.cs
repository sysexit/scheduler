using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.Application.ViewModels
{
    public class GetTimesheetsViewModel
    {
        [FromRoute]
        public int UserId { get; set; }

        [FromQuery]
        [Required]
        public DateTime Start { get; set; }

        [FromQuery]
        public DateTime End { get; set; }
    }
}
