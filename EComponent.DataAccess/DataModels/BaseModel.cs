using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComponent.DataAccess.DataModels
{
    public class BaseModel
    {
        public string ModifiedBy { get; set; }

        public bool IsDeleted { get; set; }
    }
}
