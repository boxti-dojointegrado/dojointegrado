namespace BoxTI.DojoIntegrado.API.Models.Response
{
    public class UserResponse
    {
        public UserResponse(string email, string accessToken)
        {
            Email = email;
            AccessToken = accessToken;
        }

        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
