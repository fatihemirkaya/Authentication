using Authentication.Common.DTO;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.RolePermission
{
    [DataContract]
    public class InsertRolePermissionRequestDTO : RequestDTOBase
    {
        [DataMember]
        public long PermissionId { get; set; }
        [DataMember]
        public long RoleId { get; set; }


    }
}
