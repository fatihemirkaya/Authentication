using Authentication.Common.DTO;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Authentication.Domain.Dto.User
{
    [DataContract]
    public class GetUserListResponseDTO : ResponseDTOBase
    {
        [DataMember]
        public List<GetUserResponseDTO> Users { get; set; }
    }
}
