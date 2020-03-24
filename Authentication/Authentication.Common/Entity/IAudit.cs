using System;

namespace Authentication.Common.Entity
{
    public interface IAudit
    {
        public long CreatorUserId { get; set; }
        public DateTime? LastModTime { get; set; }
        public long? ModifierUserId { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
