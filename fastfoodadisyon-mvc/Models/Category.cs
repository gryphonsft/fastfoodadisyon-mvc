using fastfoodadisyon_mvc.Models.Main;

namespace fastfoodadisyon_mvc.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
