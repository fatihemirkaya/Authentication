using Authentication.Common.DTO;
using System;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.User
{
    [DataContract]
    public class InsertUserGroupRequestDTO : RequestDTOBase
    {
        [DataMember]
        public long UserID { get; set; }
        [DataMember]
        public long GroupId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime? LastModTime { get; set; }
    }
}