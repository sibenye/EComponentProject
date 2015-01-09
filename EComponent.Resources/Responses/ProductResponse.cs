using System.Collections.Generic;

namespace EComponent.Resources
{
    public class ProductResponse
    {
        public int Id { get; set; }

        public int ProductCategoryId { get; set; }

        public string ProductCategoryName { get; set; }

        public string ProductCode { get; set; }

        public string ManufacturerName { get; set; }

        public string ManufacturerPartNumber { get; set; }

        public string Description { get; set; }

        public string Pricing { get; set; }

        public int InStock { get; set; }

        public string ImageUrl { get; set; }

        public List<AttributeValueResponse> AttributeValues { get; set; }
    }
}
