namespace EComponent.Services.Requests
{
    public class AttributeValuePostRequest : BaseRequest
    {
        public int? Id { get; set; }

        public int AttributeId { get; set; }

        public int ProductId { get; set; }

        public string Value { get; set; }
    }
}
