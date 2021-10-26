using System.ComponentModel.DataAnnotations;
using Users.Infrastructure.Requests;

namespace Users.Application.ViewModels
{
    public class GetUsersViewModel
    {
        [Required]
        public UserRequestType Type { get; set; }
    }
}
