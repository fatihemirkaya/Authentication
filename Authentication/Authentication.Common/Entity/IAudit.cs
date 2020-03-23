using System;

namespace Authentication.Common.Entity
{
    public interface IAudit
    {
        long CreatorUserId { get; }
        DateTime? LastModTime { get; }
        long? ModifierUserId { get; }
        DateTime CreationTime { get; }
    }
}
