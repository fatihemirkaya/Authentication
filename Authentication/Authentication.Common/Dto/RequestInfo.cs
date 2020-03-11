using System;
using System.Runtime.Serialization;

namespace Authentication.Common.DTO
{
    [DataContract]
    public class RequestInfo
    {
        [DataMember]
        public Guid TrackId { get; set; }

        [DataMember]
        public DateTime MessageSendTime { get; set; }

        [DataMember]
        public string ClientCode { get; set; }

        [DataMember]
        public string ClientPassword { get; set; }
    }
}