using Authentication.Common.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Domain.Dto.Permission
{
    [DataContract]
    public class UpdatePermissionsRequestDTO : RequestDTOBase
    {
        [DataMember]
        public int PermissionID { get; set; }
        [DataMember]
        public string PermissionName { get; set; }
        [DataMember]
        public string PermissionDescription { get; set; }

        [DataMember]
        public string ActionName { get; set; }
    }
}
