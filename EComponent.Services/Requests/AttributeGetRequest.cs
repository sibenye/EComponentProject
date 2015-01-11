namespace EComponent.Services.Requests
{
    public class AttributeGetRequest
    {
        public int? Id { get; set; }

        public string AttributeName { get; set; }

        public int? ProductCategoryId { get; set; }
    }
}
