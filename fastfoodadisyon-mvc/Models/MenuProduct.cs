using fastfoodadisyon_mvc.Models.Main;

namespace fastfoodadisyon_mvc.Models
{
    public class MenuProduct : BaseEntity
    {
        public int MenuId { get; set; }
        public Menu? Menu { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
