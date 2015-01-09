using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    [Table("ecomponentdb.products")]
    public partial class product
    {
        public product()
        {
            attributeValues = new HashSet<attributeValue>();
        }

        public int Id { get; set; }

        public int ProductCategoryId { get; set; }

        [Required]
        [StringLength(45)]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(45)]
        public string ManufacturerName { get; set; }

        [Required]
        [StringLength(25)]
        public string ManufacturerPartNumber { get; set; }

        [StringLength(160)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Pricing { get; set; }

        public int InStock { get; set; }

        [StringLength(500)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(15)]
        public string CreatedBy { get; set; }

        [Required]
        [StringLength(15)]
        public string ModifiedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; }

        public virtual ICollection<attributeValue> attributeValues { get; set; }

        public virtual productCategory productCategory { get; set; }
    }
}
