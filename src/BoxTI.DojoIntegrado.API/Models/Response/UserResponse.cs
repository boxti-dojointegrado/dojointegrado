namespace BoxTI.DojoIntegrado.API.Models.Response
{
    public class UserResponse
    {
        public UserResponse(string email)
        {
            Email = email;
        }

        public string Email { get; set; }
    }
}
