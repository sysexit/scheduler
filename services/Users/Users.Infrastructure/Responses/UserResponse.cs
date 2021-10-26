using Users.Domain.Dto;

namespace Users.Infrastructure.Responses
{
    public class UserResponse
    {
        public User User { get; }

        public UserResponse(Domain.Dto.User user)
        {
            User = user;
        }
    }
}
