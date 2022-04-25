using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Domain.Models
{
   public class Material : BaseModel
    {
        public string Name { get; set; }
        public double Rb { get; set; }
        public double Eb { get; set; }
        public string Definition { get; set; }
    }
}
