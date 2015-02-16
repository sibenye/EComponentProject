using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    public class ProductAttribute : BaseModel
    {
        public int Id { get; set; }

        public string AttributeName { get; set; }
    }
}
