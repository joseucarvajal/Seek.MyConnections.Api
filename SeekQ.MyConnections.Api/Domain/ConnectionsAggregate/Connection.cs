using App.Common.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeekQ.MyConnections.Api.Domain.ConnectionsAggregate
{
    public class Connection : BaseEntity
    {
        public Guid IdUser { get; set; }
        public string ConnectionNickName { get; set; }
        public string ConnectionFirstName { get; set; }
        public bool ConnectionIsFirstNameVisible { get; set; }
        public string ConnectionLastName { get; set; }
        public bool ConnectionIsLastNameVisible { get; set; }
        public int ConnectionAge { get; set; }
        public bool ConnectionIsAgeVisible { get; set; }
        public string ConnectionAvatar { get; set; }
        public bool ConnectionIsAvatar { get; set; }
        public Guid ConnectionUserId { get; set; }
        public bool Blocked { get; set; }

        public Connection() { }
    }
}
