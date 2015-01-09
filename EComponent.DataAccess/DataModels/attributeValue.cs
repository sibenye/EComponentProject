using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    [Table("ecomponentdb.attributeValues")]
    public partial class attributeValue
    {
        public int Id { get; set; }

        public int AttributeId { get; set; }

        public int ProductId { get; set; }

        [Required]
        [StringLength(45)]
        public string Value { get; set; }

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

        public virtual attribute attribute { get; set; }

        public virtual product product { get; set; }
    }
}
