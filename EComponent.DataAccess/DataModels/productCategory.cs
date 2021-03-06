using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EComponent.DataAccess.DataModels
{
    public class ProductCategory : BaseModel
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string CategoryName { get; set; }
    }
}
