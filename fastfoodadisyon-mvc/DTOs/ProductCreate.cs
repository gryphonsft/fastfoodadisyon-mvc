namespace fastfoodadisyon_mvc.DTOs
{
    public sealed class ProductCreate
    {
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public string CategoryID { get; set; } = string.Empty;
    }
}
