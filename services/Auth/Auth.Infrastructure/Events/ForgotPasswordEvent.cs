﻿using Auth.Domain.Events;

namespace Auth.Infrastructure.Events
{
    public class ForgotPasswordEvent : Event
    {
        public string Token { get; private set; }
        public string Email { get; private set; }
        public string First { get; private set; }
        public string Last { get; private set; }

        public ForgotPasswordEvent(string token, string email, string first, string last)
        {
            Token = token;
            Email = email;
            First = first;
            Last = last;
        }
    }
}
