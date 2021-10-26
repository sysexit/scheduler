using Auth.Domain.Interfaces;
using Auth.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Presenters
{
    public sealed class LoginPresenter : IOutputPort<LoginResponse>
    {
        public LoginResponse data { get; set; }

        public void Handle(LoginResponse response)
        {
            data = response;
        }
    }
}
