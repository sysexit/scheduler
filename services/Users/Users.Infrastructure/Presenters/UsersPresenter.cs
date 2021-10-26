using Users.Domain.Interfaces;
using Users.Infrastructure.Responses;

namespace Users.Infrastructure.Presenters
{
    public sealed class UsersPresenter : IOutputPort<UsersResponse>
    {
        public UsersResponse data { get; set; }

        public void Handle(UsersResponse response)
        {
            data = response;
        }
    }
}
