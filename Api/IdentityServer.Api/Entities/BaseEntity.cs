using System;

namespace IdentityServer.Api.Entities
{
    public abstract class BaseEntity
    {
        public long ID { get; set; }
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset ModifiedOn { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
