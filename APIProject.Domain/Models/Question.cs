using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Domain.Models
{
   public class Question : BaseModel
    {
        public string cauhoi { get; set; }
        public string cautraloi { get; set; }
        public int Subject { get; set; }
        public int CountIt  { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
