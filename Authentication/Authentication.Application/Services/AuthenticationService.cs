using Authentication.Common.Constants;
using Authentication.Common.Exceptions;
using Authentication.Common.Security;
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

        public async Task<InsertUserResponseDTO> InsertUserAsync(InsertUserRequestDTO request)
        {
            InsertUserResponseDTO response = new InsertUserResponseDTO();
            string password = request.Password;
            var hashedpassword = HashHelper.GetEncryptedString(password);
            User createdUser = new User(request.UserName, request.Name, request.SurName, request.Email, hashedpassword[0], hashedpassword[1]);
            await uow.User.InsertAsync(createdUser);
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

            if (String.IsNullOrEmpty(request.UserName) || String.IsNullOrEmpty(request.Password))
            {
                throw new BusinessException(ResponseCode.UserNameOrUserPasswordNotNull);
            }
            
            var user = await uow.User.ValidateUser(request.UserName, request.Password);

            var accessToken = await this.CreateAccessToken(user);

            var result = Imapper.Map<ValidateUserResponseDTO>(user);

            result.Token = accessToken.Token;
            result.RefreshToken = accessToken.RefreshToken;
            result.TokenExpireDate = accessToken.Expiration;

            return result;
        }

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

      


    }
}