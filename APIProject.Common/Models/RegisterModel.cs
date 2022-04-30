using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Common.Models
{
  public  class RegisterModel
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
