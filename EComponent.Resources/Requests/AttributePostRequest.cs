using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponent.Resources
{
    public class AttributePostRequest : BaseRequest
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? ProductCategoryId { get; set; }
    }
}
