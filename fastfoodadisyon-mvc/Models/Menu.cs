namespace fastfoodadisyon_mvc.Models
{
    public class Menu
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }

        public ICollection<MenuProduct>? MenuProducts { get; set; }
    }
}
