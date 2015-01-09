﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponent.Resources
{
    public class AttributeValuePostRequest : BaseRequest
    {
        public int? Id { get; set; }

        public int AttributeId { get; set; }

        public int ProductId { get; set; }

        public string Value { get; set; }
    }
}
