using System.Runtime.Serialization;

namespace Authentication.Common.DTO
{
    [DataContract]
    public class RequestDTOBase
    {
        public RequestDTOBase()
        {
            this.RequestInfo = new RequestInfo();
            this.DataInfo = new RequestDataInfo();
        }

        [DataMember]
        public RequestInfo RequestInfo { get; set; }

        [DataMember]
        public RequestDataInfo DataInfo { get; set; }
    }
}
