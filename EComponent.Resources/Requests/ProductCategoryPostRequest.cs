namespace EComponent.Resources
{
    public class ProductCategoryPostRequest : BaseRequest
    {
        public int? Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }
    }
}
