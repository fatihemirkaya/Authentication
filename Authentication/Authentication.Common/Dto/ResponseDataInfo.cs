using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Common.DTO
{
    [DataContract]
    public class ResponseDataInfo
    {
        [DataMember]
        public int TotalCount { get; set; }
    }
}
