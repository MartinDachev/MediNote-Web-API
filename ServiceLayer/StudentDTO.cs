using ServiceLayer.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class StudentDTO
    {
        public StudentDTO()
        {

        }

        public int Id { get; set; }

        [Required]
        [NIN]
        public string StudentNIN { get; set; }

        [Required]
        public string StudentName { get; set; }

        [Required]
        public string StudentAddress{ get; set; }

        [Required]
        public int StudentAge { get; set; }        
    }
}
