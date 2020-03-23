using Authentication.Common.DTO;
using System.Runtime.Serialization;

namespace Authentication.Domain.Dto.User
{
    [DataContract]
    public class GetUserResponseDTO : ResponseDTOBase
    {
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string SurName { get; set; }
        [DataMember]
        public string Email { get; set; }

    }
}
