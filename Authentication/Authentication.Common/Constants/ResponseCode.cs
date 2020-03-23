namespace Authentication.Common.Constants
{
    public class ResponseCode
    {
        public const string Success = "0001";
        public const string Error = "0002";
        public const string ServiceCommunicationError = "0003";
        public const string UserNameOrUserPasswordNotNull = "0004";
        public const string UserNotFound = "0005";
        public const string PasswordNotMatch = "0006";
        public const string PermissionNotFound = "0007";
        public const string RoleNotFound = "0008";
        public const string GroupNotFound = "0009";
        public const string ApplicationNotAuthorized = "0010";
        public const string OldPasswordNotMatch = "0011";
        public const string RequestDataInfoMandatory = "0012";
        public const string UserMembershipNotFound = "0013";
        public const string UserNameIsInUse = "0014";
        public const string EmailInUse = "0015";
        public const string UserIsNotActive = "0016";
        public const string IsRequiredPhoto = "0017";
        public const string GroupNameDuplicate = "0018";
        public const string RoleNameDuplicate = "0019";
        public const string RoleApproverWaiting = "0051";
        public const string PassMinLengthError = "0020";
        public const string PassMaxLengthError = "0021";
        public const string PassCompNumberError = "0022";
        public const string PassCompLetterError = "0023";
        public const string PassCompNumberLetterError = "0024";
        public const string PassCompNumberUpperLowerLetterError = "0025";
        public const string PassCompNumberLetterSpecialCharError = "0026";
        public const string PassCompNumberorSpecialCharUpperLowerLetterError = "0027";
        public const string PassCompNumberUpperLowerLetterSpecialCharError = "0028";
        public const string UserIsLockedOut = "0029";
        public const string PasswordHistoryError = "0030";
        public const string ApplicationNotFound = "0031";
        public const string MenuNameDuplicate = "0032";
        public const string TokenExpire = "0033";
        public const string ValidataionError = "0034";

    }
}
