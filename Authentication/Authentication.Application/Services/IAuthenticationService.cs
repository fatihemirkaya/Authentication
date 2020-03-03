using Authentication.Domain.Dto.User;
using Authentication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Services
{
    public interface IAuthenticationService
    {
        public Task<InsertUserResponseDTO> InsertUserAsync(InsertUserRequestDTO request);

        public Task<ValidateUserResponseDTO> ValidateUserAsync(ValidateUserRequestDTO request);

        public GetUserListResponseDTO GetUsers(GetUserRequestDTO request);

    }
}
