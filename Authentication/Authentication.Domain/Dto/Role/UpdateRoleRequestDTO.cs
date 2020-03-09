using Authentication.Common.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Domain.Dto.Role
{
    [DataContract]
    public class UpdateRoleRequestDTO : RequestDTOBase
    {
        [DataMember]
        public int RoleID { get; set; }
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string RoleDescription { get; set; }

    }
}
