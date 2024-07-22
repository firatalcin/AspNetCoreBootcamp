using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppNTier.Dtos.WorkDtos
{
    public class WorkCreateDto
    {
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}
