namespace API_YETI.DTOs
{
    public class UserRegisterDTO
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;  // senha original não criptografada
    }
}
