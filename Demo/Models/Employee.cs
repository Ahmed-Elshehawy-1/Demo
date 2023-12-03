using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage ="The Maximum Length = 20")]
        [MinLength(2,ErrorMessage ="The Minimum Length = 2")] 
        public string Name { get; set; }
        [Range(2000,8000)]
        [RegularExpression(@"[0-9]{4}",ErrorMessage ="The Salary must be 4 numbers")]
        public double salary { get; set; }
        [RegularExpression(@"[a-z]+\.(jpg|png)", ErrorMessage = "The Image Name must be contain char and (jpg Or png)")]
        public string Image { get; set; }
        [ForeignKey("Department")]
        public int Dept_Id { get; set; }
        public virtual Department Department { get; set; }
    }
}