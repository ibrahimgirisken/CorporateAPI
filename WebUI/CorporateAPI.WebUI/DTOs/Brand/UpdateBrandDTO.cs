namespace CorporateAPI.WebUI.DTOs.Brand
{
    public class UpdateBrandDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Order { get; set; }
        public bool Status { get; set; } = false;
    }
}
