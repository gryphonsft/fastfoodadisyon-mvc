namespace fastfoodadisyon_mvc.DTOs
{
    public sealed class UserCreate
    {
        public string userName { get; set; } = string.Empty;
        public string passWord { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
