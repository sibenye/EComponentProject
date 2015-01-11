using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    public class attribute : BaseModel
    {
        public attribute()
        {
            attributeValues = new HashSet<attributeValue>();
        }

        public int Id { get; set; }

        public string AttributeName { get; set; }

        public virtual ICollection<attributeValue> attributeValues { get; set; }
    }
}
