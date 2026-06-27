using fastfoodadisyon_mvc.Models.Main;

namespace fastfoodadisyon_mvc.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public int CategoryID { get; set; }
        public Category? Category { get; set; }

        public ICollection<MenuProduct> MenuProducts { get; set; } = new List<MenuProduct>();
    }
}
