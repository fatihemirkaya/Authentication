using System;
using System.Collections.Generic;
using System.Text;

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
