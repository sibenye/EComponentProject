﻿namespace EComponent.Services.Requests
{
    public class AttributePostRequest : BaseRequest
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public int? ProductCategoryId { get; set; }
    }
}
