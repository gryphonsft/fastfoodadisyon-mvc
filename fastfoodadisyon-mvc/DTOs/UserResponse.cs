namespace fastfoodadisyon_mvc.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string userName { get; set; } = string.Empty;
        public string passWord { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
