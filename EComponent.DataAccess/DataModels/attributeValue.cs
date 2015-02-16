using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    public class AttributeValue : BaseModel
    {
        public int Id { get; set; }

        public int AttributeId { get; set; }

        public int ProductId { get; set; }

        public string Value { get; set; }
    }
}
