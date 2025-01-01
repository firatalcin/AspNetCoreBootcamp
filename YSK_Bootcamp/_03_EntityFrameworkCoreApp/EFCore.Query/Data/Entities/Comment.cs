using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Query.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
