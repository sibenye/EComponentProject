using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    [Table("ecomponentdb.productCategories")]
    public partial class productCategory
    {
        public productCategory()
        {
            attributes = new HashSet<attribute>();
            products = new HashSet<product>();
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }

        [Required]
        [StringLength(45)]
        public string Name { get; set; }

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

        public virtual ICollection<attribute> attributes { get; set; }

        public virtual ICollection<product> products { get; set; }
    }
}
