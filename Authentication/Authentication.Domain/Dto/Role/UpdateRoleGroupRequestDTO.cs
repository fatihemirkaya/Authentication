using Authentication.Common.DTO;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.Role
{
    [DataContract]
    public class UpdateRoleGroupRequestDTO : RequestDTOBase
    {
        [DataMember]
        public int RoleGroupID { get; protected set; }
        [DataMember]
        public long? RoleID { get; protected set; }
        [DataMember]
        public long GroupID { get; protected set; }
    }
}
