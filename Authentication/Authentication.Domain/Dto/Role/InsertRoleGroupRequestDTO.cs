using Authentication.Common.DTO;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.Role
{
    [DataContract]
    public class InsertRoleGroupRequestDTO : RequestDTOBase
    {
        [DataMember]
        public long RoleID { get; set; }
        [DataMember]
        public long GroupID { get; set; }
    }
}
