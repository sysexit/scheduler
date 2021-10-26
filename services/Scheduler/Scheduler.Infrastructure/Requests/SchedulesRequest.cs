using System;
using NodaTime;
using Scheduler.Infrastructure.Validators;

namespace Scheduler.Infrastructure.Requests
{
    public class SchedulesRequest : ScheduleRequest
    {
        public SchedulesRequest(int id)
        {
            Id = id;
        }

        public SchedulesRequest(Instant start, Instant end)
        {
            Start = start;
            End = end;
        }

        public SchedulesRequest(int groupId, Instant start, Instant end)
        {
            GroupId = groupId;
            Start = start;
            End = end;
        }

        public SchedulesRequest(int userId, Instant start, Instant end, int position, string remoteIPAddress)
        {
            UserId = userId;
            Start = start;
            End = end;
            Position = position;
            RemoteIpAddress = remoteIPAddress;
        }

        public SchedulesRequest(int id, int userId, Instant start, Instant end, int position, string remoteIPAddress) : this(userId, start, end, position, remoteIPAddress)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new TimesheetsRequestValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
