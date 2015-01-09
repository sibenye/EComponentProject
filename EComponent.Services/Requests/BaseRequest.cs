using System;

namespace EComponent.Services.Requests
{
    public class BaseRequest
    {
        public string CreatedBy { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
}
