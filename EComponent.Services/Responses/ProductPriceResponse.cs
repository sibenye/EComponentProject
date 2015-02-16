using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponent.Services.Responses
{
    public class ProductPriceResponse
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ProductCode { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }
    }
}
