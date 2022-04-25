using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Common.Models
{
  public class AddCustomerRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
