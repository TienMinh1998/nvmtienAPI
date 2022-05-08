
using System.ComponentModel.DataAnnotations;
namespace APIProject.Domain.Models
{
    public class Customer : BaseModel
    {
        [StringLength(15)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
    }
}
