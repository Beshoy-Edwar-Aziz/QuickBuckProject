using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBuck.Core.Models
{
    public class Requirements:BaseEntity
    {
        public string ReqName { get; set; }
        public string ReqPriority { get; set; }
    }
}
