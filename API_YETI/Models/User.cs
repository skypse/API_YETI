namespace API_YETI.Models
{
    // representa usuário
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString(); // gera um id único
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role {  get; set; } = "User"; // padrão definido como usuário
        public string DataCreationAccount { get; set; } = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"); // puxa a data atual
    }
}
