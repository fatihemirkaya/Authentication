using System.Runtime.Serialization;

namespace Authentication.Common.DTO
{
    [DataContract]
    public class ResponseInfo
    {
        [DataMember]
        public bool IsSuccess { get; set; }

        [DataMember]
        public string responseCode { get; set; }

        [DataMember]
        public string message { get; set; }



    }
}
