using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Common.Entity
{
    public interface ISoftDeleted
    {
        bool IsDeleted { get; }
    }
}
