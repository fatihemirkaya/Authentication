using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Common.DTO
{
    [DataContract]
    public class RequestDataInfo
    {
        [DataMember]
        public int? PageIndex { get; set; }

        [DataMember]
        public int? PageSize { get; set; }
    }
}
