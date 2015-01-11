using System;

namespace EComponent.Services.Requests
{
    public class BaseRequest
    {
        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
