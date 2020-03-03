using Authentication.Common.DTO;
using Authentication.Common.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Domain.Dto.User
{
    [DataContract]
    public class GetUserRequestDTO : RequestDTOBase
    {
        [DataMember]
        public long UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public StatusType Status { get; set; }
    }
}
