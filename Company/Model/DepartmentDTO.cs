using Company.Data;
using System.ComponentModel.DataAnnotations;

namespace Company.Model
{
   
    public class CreateDepartmentDTO
    {

        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "Department Name is too Long.")]
        public string DepartmentName { get; set; }

        [Required]
        [StringLength(maximumLength: 4, ErrorMessage = "Short Name is Long.")]
        public string ShortName { get; set; }
    }

    public class DepartmentDTO : CreateDepartmentDTO 
    {
        public int Id { get; set; }
        public virtual IList<Employees> Employees { get; set; }

    }
}
