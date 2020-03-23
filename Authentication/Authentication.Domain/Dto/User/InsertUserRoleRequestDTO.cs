using Authentication.Common.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Domain.Dto.User
{
    [DataContract]
    public class InsertUserRoleRequestDTO : RequestDTOBase
    {
        [DataMember]
        public long UserID { get; set; }
        [DataMember]
        public long RoleId { get; set; }

    }
}