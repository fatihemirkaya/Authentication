using System.Runtime.Serialization;

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
