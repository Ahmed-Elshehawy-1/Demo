using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Department
    {
        public int Id { get; set; }
        [Display(Name = "Department Name")]
        //[DataType(DataType.Password)]
        public string Name { get; set; }
        [Display(Name = "Manager")]
        public string ManagerName { get; set; }

        public virtual List<Employee> Students { get; set; }
    }
}