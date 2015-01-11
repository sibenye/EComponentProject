using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    public class product : BaseModel
    {
        public product()
        {
            attributeValues = new HashSet<attributeValue>();
        }

        public int Id { get; set; }

        public int ProductCategoryId { get; set; }

        public string ProductCode { get; set; }

        public string ManufacturerName { get; set; }

        public string ManufacturerPartNumber { get; set; }

        public string Description { get; set; }

        public string Pricing { get; set; }

        public int InStock { get; set; }

        public string ImageUrl { get; set; }
        
        public virtual ICollection<attributeValue> attributeValues { get; set; }

        public virtual productCategory productCategory { get; set; }
    }
}
