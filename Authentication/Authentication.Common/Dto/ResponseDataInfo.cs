using System.Runtime.Serialization;

namespace Authentication.Common.DTO
{
    [DataContract]
    public class ResponseDataInfo
    {
        [DataMember]
        public int TotalCount { get; set; }
    }
}
