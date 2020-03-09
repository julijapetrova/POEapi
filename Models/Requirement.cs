using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POEapi.Models
{
    public class Requirement
    {
        public string name { get; set; }
        public List<List<object>> values { get; set; }
        public int displayMode { get; set; }
    }
}
