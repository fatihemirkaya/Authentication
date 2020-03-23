using Authentication.Common.DTO;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.RolePermission
{
    [DataContract]
    public class UpdateRolePermissionRequestDTO : RequestDTOBase
    {
        [DataMember]
        public int RolePermissionID { get; set; }
        [DataMember]
        public long PermissionId { get; set; }
        [DataMember]
        public long RoleId { get; set; }
    }
}
