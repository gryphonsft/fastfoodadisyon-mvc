using fastfoodadisyon_mvc.Models.Main;

namespace fastfoodadisyon_mvc.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string CategoryID { get; set; } = string.Empty;
        public Category? Category { get; set; } 
    }
}
