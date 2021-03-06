﻿using Authentication.Common.DTO;
using Authentication.Common.Enum;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.User
{
    [DataContract]
    public class InsertUserRequestDTO : RequestDTOBase
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public UserType UserType { get; set; }
        [DataMember]
        public long ApplicationId { get; set; }


    }
}
