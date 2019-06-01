using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevCodeCamp.Domain.Models
{
    public class RateInstructorRequest
    {
        public int InstructorId { get; set; }
        public int Rating { get; set; }
    }
}
