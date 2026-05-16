using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetChildrenCareSystem.Models
{
    public class Child
    {
        // Properties - Encapsulation
        public int ChildID { get; set; }
        public string ChildName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string FoundLocation { get; set; }
        public string ChildStatus { get; set; }
        public int OrpID { get; set; }
        public int FouID { get; set; }
    }
}
