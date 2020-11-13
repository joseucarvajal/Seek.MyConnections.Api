using System;

namespace SeekQ.MyConnections.Api.Application.Queries
{
    public class GetBlockedUsersrViewModel
    {
        public Guid IdConnection { get; set; }
        public string Avatar { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public Guid ConnectionUserId { get; set; }
    }
}
