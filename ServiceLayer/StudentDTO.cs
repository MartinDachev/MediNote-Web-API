using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class StudentDTO
    {
        public string StudentNIN { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress{ get; set; }
        public int StudentAge { get; set; }        
    }
}
