using System;
using System.Collections.Generic;
using System.Text;

namespace APIProject.Domain.Models
{
    public class Category  : BaseModel
    {
        public string Name { get; set; }
        public int Status { get; set; }
    }
}
