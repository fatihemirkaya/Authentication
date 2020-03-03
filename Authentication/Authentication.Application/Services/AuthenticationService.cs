using Authentication.Common.Constants;
using Authentication.Common.Exceptions;
using Authentication.Common.Security;
using Authentication.Domain.Dto.User;
using Authentication.Domain.Entity;
using Authentication.Domain.Repository.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUnitOfWork uow;

        public AuthenticationService(IUnitOfWork _uow)
        {
            uow = _uow;
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
            //var result = Imapper.Map<GetUserListResponseDTO>(users);
            return new GetUserListResponseDTO();
        }

        public async Task<ValidateUserResponseDTO> ValidateUserAsync(ValidateUserRequestDTO request)
        {

            if (String.IsNullOrEmpty(request.UserName) || String.IsNullOrEmpty(request.Password))
            {
                throw new BusinessException(ResponseCode.UserNameOrUserPasswordNotNull);
            }
            
            var user = await uow.User.ValidateUser(request.UserName, request.Password);

            //var accessToken = await this.CreateAccessToken(user);



            //var result = Imapper.Map<ValidateUserResponseDTO>(user);

            //result.Token = accessToken.Token;
            //result.RefreshToken = accessToken.RefreshToken;
            //result.TokenExpireDate = accessToken.Expiration;

            return new ValidateUserResponseDTO();
        }

    }
}