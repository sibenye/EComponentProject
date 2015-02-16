using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    public class Product : BaseModel
    {
        public int Id { get; set; }

        public int ProductCategoryId { get; set; }

        public string ProductCode { get; set; }

        public string ManufacturerName { get; set; }

        public string ManufacturerPartNumber { get; set; }

        public string Description { get; set; }

        public string Pricing { get; set; }

        public int InStock { get; set; }

        public string ImageUrl { get; set; }
    }
}
