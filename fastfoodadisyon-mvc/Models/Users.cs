using fastfoodadisyon_mvc.Models.Main;

namespace fastfoodadisyon_mvc.Models
{
    public class Users : BaseEntity
    {
        public string userName { get; set; } = string.Empty;
        public string passWord { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
