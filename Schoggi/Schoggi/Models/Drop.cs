using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schoggi.Models
{
    public class Drop
    {
        public int ID { get; set; }
        public string Text { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
