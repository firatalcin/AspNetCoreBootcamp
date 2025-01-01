using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppNTier.Entities.Concrete
{
    public class Work : BaseEntity
    {
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
