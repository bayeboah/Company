using System.ComponentModel.DataAnnotations;

namespace Company.Model
{
    public class CreateEmployeesDTO
    {

        [Required]
        [StringLength(100, ErrorMessage ="Name is too Long.")]
        public string EmployeeName { get; set; }

        [Required]
        public int EmployeeAge { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = " Too Long.")]
        public string Residence { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Too Long.")]
        public string Hometown { get; set; }

        [Required]
        public int DeparmentId { get; set; }

    }


    public class EmployeesDTO : CreateEmployeesDTO
    {
        public int Id { get; set; }

        public DepartmentDTO Department { get; set; }
    }
}
