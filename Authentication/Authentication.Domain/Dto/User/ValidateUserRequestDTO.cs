using Authentication.Common.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Domain.Dto.User
{
    [DataContract]
    public class ValidateUserRequestDTO : RequestDTOBase
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Password { get; set; }

    }
}
