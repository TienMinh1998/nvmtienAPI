using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Common.Request
{
   public class AddNewMaterialRequest
    {
        public string Name { get; set; }
        public double Rb { get; set; }
        public double Rbt { get; set; }
        public double Eb { get; set; }
        public string Definition { get; set; }
    }
}
