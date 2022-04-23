namespace E02.EFCoreApp
{
    public class TokenResponse
    {
        public string Token { get; set; }

        public TokenResponse(string token)
        {
            Token = token;
        }
    }
}
