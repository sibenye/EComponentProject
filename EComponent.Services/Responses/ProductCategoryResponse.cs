using System.Collections.Generic;

namespace EComponent.Services.Responses
{
    public class ProductCategoryResponse
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Name { get; set; }

        public List<ProductResponse> Products { get; set; } 
    }
}
