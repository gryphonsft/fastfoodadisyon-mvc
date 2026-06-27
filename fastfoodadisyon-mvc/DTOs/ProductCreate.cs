namespace fastfoodadisyon_mvc.DTOs
{
    public sealed class ProductCreate
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int CategoryID { get; set; } 
    }
}
