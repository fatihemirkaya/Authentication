using Authentication.Common.Constants;
using Authentication.Common.Exceptions;
using Authentication.Common.Security;
using Authentication.Domain.Dto.Permission;
using Authentication.Domain.Dto.Role;
using Authentication.Domain.Dto.RolePermission;
using Authentication.Domain.Dto.User;
using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Uow;
using Authentication.Domain.Token;
using AutoMapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUnitOfWork uow;
        private readonly IMapper Imapper;
        private readonly TokenOptions tokenOpt;
        private readonly ITokenHandler tokenHandler;

        public AuthenticationService(IUnitOfWork _uow, IMapper _iMapper, ITokenHandler _tokenHandler, IOptions<TokenOptions> _tokenOpt)
        {
            uow = _uow;
            this.Imapper = _iMapper;
            this.tokenHandler = _tokenHandler;
            this.tokenOpt = _tokenOpt.Value;
        }


        #region User

        public async Task<InsertUserResponseDTO> InsertUserAsync(InsertUserRequestDTO request)
        {
            InsertUserResponseDTO response = new InsertUserResponseDTO();

            var app = await uow.Application.GetAsync(x => x.Id == request.ApplicationId);

            if (app == null)
            {
                throw new BusinessException(ResponseCode.ApplicationNotFound);
            }

            string password = request.Password;
            var hashedpassword = HashHelper.GetEncryptedString(password);
            User createdUser = new User(request.UserName, request.Name, request.SurName, request.Email, hashedpassword[0], hashedpassword[1]);


            await uow.User.InsertAsync(createdUser);
            await uow.CompleteAsync();
            UserApplication usrApp = new UserApplication(app.Id, createdUser.Id);

            
            await uow.UserApplication.InsertAsync(usrApp);
            await uow.CompleteAsync();

            return response;
        }

        public GetUserListResponseDTO GetUsers(GetUserRequestDTO request)
        {
            var users = uow.User.GetUsers(request.UserID, request.UserName, request.Name, request.SurName, request.Email);
            var result = Imapper.Map<GetUserListResponseDTO>(users);
            return result;
        }

        public async Task<ValidateUserResponseDTO> ValidateUserAsync(ValidateUserRequestDTO request)
        {

            if (String.IsNullOrEmpty(request.UserName) || String.IsNullOrEmpty(request.Password) || request.RequestInfo.ApplicationId <= 0)
            {
                throw new BusinessException(ResponseCode.UserNameOrUserPasswordNotNull);
            }

            var user = await uow.User.ValidateUser(request.UserName, password: request.Password, appId: request.RequestInfo.ApplicationId);

            var accessToken = await this.CreateAccessToken(user);

            var result = Imapper.Map<ValidateUserResponseDTO>(user);

            result.Token = accessToken.Token;
            result.RefreshToken = accessToken.RefreshToken;
            result.TokenExpireDate = accessToken.Expiration;

            return result;
        }

        #endregion

        public async Task<InsertRoleResponseDTO> InsertRoleAsync(InsertRoleRequestDTO request)
        {
            InsertRoleResponseDTO response = new InsertRoleResponseDTO();

            if (request.GroupId < 1 || String.IsNullOrEmpty(request.RoleName) || String.IsNullOrEmpty(request.RoleDescription))
            {
                throw new BusinessException(ResponseCode.ValidataionError);
            }

            var grp = await uow.Group.GetAsync(x => x.Id == request.GroupId);

            if (grp == null)
            {
                throw new BusinessException(ResponseCode.GroupNotFound);
            }


            Role createdRole = new Role(request.RoleName, request.RoleDescription, grp);

            await uow.Role.InsertAsync(createdRole);
            await uow.CompleteAsync();

            return response;
        }

        public async Task<InsertPermissionResponseDTO> InsertPermissionAsync(InsertPermissionRequestDTO request)
        {
            InsertPermissionResponseDTO response = new InsertPermissionResponseDTO();

            if (String.IsNullOrEmpty(request.PermissionName) || String.IsNullOrEmpty(request.PermissionDescription) || String.IsNullOrEmpty(request.ActionName))
            {
                throw new BusinessException(ResponseCode.ValidataionError);
            }

            Permission createdGroup = new Permission(request.PermissionName, request.PermissionDescription, request.ActionName,request.RequestInfo.ApplicationId);

            await uow.Permission.InsertAsync(createdGroup);
            await uow.CompleteAsync();

            return response;
        }

        public async Task<InsertRolePermissionResponseDTO> InsertRolePermissionAsync(InsertRolePermissionRequestDTO request)
        {
            InsertRolePermissionResponseDTO response = new InsertRolePermissionResponseDTO();

            if (request.PermissionId < 1 || request.RoleId < 1)
            {
                throw new BusinessException(ResponseCode.ValidataionError);
            }

            var permission = await uow.Permission.GetAsync(x => x.Id == request.PermissionId);

            if (permission == null)
            {
                throw new BusinessException(ResponseCode.ValidataionError);
            }

            var role = await uow.Role.GetAsync(x => x.Id == request.RoleId);

            if (role == null)
            {
                throw new BusinessException(ResponseCode.RoleNotFound);
            }

            RolePermission createdRolePermission = new RolePermission(role, permission);

            await uow.RolePermission.InsertAsync(createdRolePermission);
            await uow.CompleteAsync();

            return response;
        }

        public async Task<InsertRoleGroupResponseDTO> InsertRoleGroupAsync(InsertRoleGroupRequestDTO request)
        {

            InsertRoleGroupResponseDTO response = new InsertRoleGroupResponseDTO();

            if (request.GroupID < 1 || request.RoleID < 1)
            {
                throw new BusinessException(ResponseCode.ValidataionError);
            }
            var role = await uow.Role.GetAsync(x => x.Id == request.RoleID);

            if (role == null)
            {
                throw new BusinessException(ResponseCode.RoleNotFound);
            }
            var group = await uow.Group.GetAsync(x => x.Id == request.GroupID);

            if (group == null)
            {
                throw new BusinessException(ResponseCode.GroupNotFound);
            }

            RoleGroup roleGroup = new RoleGroup(role, group);

            await uow.RoleGroup.InsertAsync(roleGroup);
            await uow.CompleteAsync();


            return response;
        }

        public async Task<InsertUserGroupResponseDTO> InsertUserGroupAsync(InsertUserGroupRequestDTO request)
        {

            InsertUserGroupResponseDTO response = new InsertUserGroupResponseDTO();

            if (request.UserID < 1 || String.IsNullOrEmpty(request.Description) || request.LastModTime == null)
            {
                throw new BusinessException(ResponseCode.ValidataionError);
            }


            UserGroup userGroup = new UserGroup(request.UserID, request.GroupId, request.Description, request.LastModTime);

            await uow.UserGroup.InsertAsync(userGroup);
            await uow.CompleteAsync();


            return response;
        }

        public async Task<InsertUserRoleResponseDTO> InsertUserRole(InsertUserRoleRequestDTO request)
        {

            InsertUserRoleResponseDTO response = new InsertUserRoleResponseDTO();

            if (request.UserID < 1 || request.RoleId <1)
                throw new BusinessException(ResponseCode.ValidataionError);

            UserRole userRole = new UserRole(request.RoleId,request.UserID);

            await uow.UserRole.InsertAsync(userRole);
            await uow.CompleteAsync();


            return response;
        }



        #region Token

        private async Task<AccessToken> CreateAccessToken(User user)
        {
            var accessToken = tokenHandler.CreateAccessToken(user);

            var usertkn = uow.UserToken.GetUserTokenByUserId(user.Id);

            if (usertkn != null)
            {
                uow.UserToken.DeleteUserToken(usertkn);
            }

            UserToken userToken = new UserToken(user.Id, accessToken.RefreshToken, accessToken.Expiration.AddMinutes(tokenOpt.RefreshTokenExpiration));
            await uow.UserToken.InsertAsync(userToken);
            uow.Complete();

            return accessToken;
        }

        #endregion






    }
}