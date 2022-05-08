using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace APIProject.Domain.Models
{
   
    public class User :BaseModel
    {
        public string  Name { get; set; }
        public string  Email { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(300)]
        public string PassWord { get; set; }
        public string Phone { get; set; }
        public string AvaterUrl { get; set; }
        public virtual IList<Category> categories { get; set; }
        public virtual IList<Question> Questions { get; set; }

    }
}
