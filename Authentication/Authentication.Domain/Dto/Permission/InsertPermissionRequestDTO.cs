using Authentication.Common.DTO;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.Permission
{
    [DataContract]
    public class InsertPermissionRequestDTO : RequestDTOBase
    {
        [DataMember]
        public string PermissionName { get; set; }
        [DataMember]
        public string PermissionDescription { get; set; }

        [DataMember]
        public string ActionName { get; set; }


    }
}
