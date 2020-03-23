using Authentication.Common.DTO;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.Role
{
    [DataContract]
    public class InsertRoleRequestDTO : RequestDTOBase
    {
        [DataMember]
        public string RoleName { get; set; }
        [DataMember]
        public string RoleDescription { get; set; }
        [DataMember]
        public long GroupId { get; set; }

    }
}
