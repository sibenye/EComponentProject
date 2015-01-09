using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    [Table("ecomponentdb.attributes")]
    public partial class attribute
    {
        public attribute()
        {
            attributeValues = new HashSet<attributeValue>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

        public int? ProductCategoryId { get; set; }

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
