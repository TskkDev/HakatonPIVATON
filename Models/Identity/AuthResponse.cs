namespace HakatonPIVATON.Models.Identity
{
    public class AuthResponse
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsCompany { get;  set; }
        public string Token { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
