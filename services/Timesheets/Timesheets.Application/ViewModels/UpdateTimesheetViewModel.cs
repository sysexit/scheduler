using System;
using System.ComponentModel.DataAnnotations;

namespace Timesheets.Application.ViewModels
{
    public class UpdateTimesheetViewModel
    {
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Start { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        public string RemoteIpAddress { get; set; }
    }
}
