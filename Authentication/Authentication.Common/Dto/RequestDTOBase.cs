
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Common.DTO
{
    [DataContract]
    public class RequestDTOBase
    {
        public RequestDTOBase()
        {
            this.Header = new RequestHeader();
            this.DataInfo = new RequestDataInfo();
        }

        [DataMember]
        public RequestHeader Header { get; set; }

        [DataMember]
        public RequestDataInfo DataInfo { get; set; }
    }
}
