
using Authentication.Common.Constants;
using Authentication.Common.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Common.DTO
{
    [DataContract]
    public class ResponseDTOBase
    {
        public ResponseDTOBase()
        {
            this.header = new ResponseHeader
            {
                responseCode = ResponseCode.Success,
                IsSuccess = true,
                message = "Success"


            };

            this.dataInfo = new ResponseDataInfo
            {
                TotalCount = 0
            };
        }

        [DataMember]
        public ResponseHeader header { get; set; }

        [DataMember]
        public ResponseDataInfo dataInfo { get; set; }
    }
}