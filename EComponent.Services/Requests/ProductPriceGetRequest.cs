using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponent.Services.Requests
{
    public class ProductPriceGetRequest
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
    }
}
