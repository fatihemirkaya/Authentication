namespace Authentication.Common.Security
{
    public interface ISecurityService
    {
        string[] Encrypt(string input);
        string Decrypt(string input, string salt);
    }
}
