﻿namespace EComponent.Services.Requests
{
    public class ProductCategoryPostRequest : BaseRequest
    {
        public int? Id { get; set; }

        public int? ParentId { get; set; }

        public string CategoryName { get; set; }
    }
}
