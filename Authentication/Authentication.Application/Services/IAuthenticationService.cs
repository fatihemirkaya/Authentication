using Authentication.Domain.Dto.Permission;
using Authentication.Domain.Dto.Role;
using Authentication.Domain.Dto.RolePermission;
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

        public Task<InsertRoleResponseDTO> InsertRoleAsync(InsertRoleRequestDTO request);

        public Task<InsertPermissionResponseDTO> InsertPermissionAsync(InsertPermissionRequestDTO request);

        public Task<InsertRolePermissionResponseDTO> InsertRolePermissionAsync(InsertRolePermissionRequestDTO request);

        public Task<InsertRoleGroupResponseDTO> InsertRoleGroupAsync(InsertRoleGroupRequestDTO request);

        public Task<InsertUserGroupResponseDTO> InsertUserGroupAsync(InsertUserGroupRequestDTO request);

    }
}
