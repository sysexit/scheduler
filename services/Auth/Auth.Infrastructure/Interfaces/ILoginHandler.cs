using Auth.Domain.Interfaces;
using Auth.Infrastructure.Requests;
using Auth.Infrastructure.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Infrastructure.Interfaces
{
    public interface ILoginHandler
    {
        Task Handle(LoginRequest message, IOutputPort<LoginResponse> outputPort);
    }
}
