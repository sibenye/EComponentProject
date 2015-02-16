namespace EComponent.Services.Requests
{
    public class ProductGetRequest
    {
        public int? Id { get; set; }

        public string ProductCode { get; set; }

        public int? ProductCategoryId { get; set; }
    }
}
