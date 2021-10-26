using Users.Domain.Interfaces;
using Users.Infrastructure.Responses;

namespace Users.Infrastructure.Presenters
{
    public sealed class UserPresenter : IOutputPort<UserResponse>
    {
        public UserResponse data { get; set; }

        public void Handle(UserResponse response)
        {
            data = response;
        }
    }
}
