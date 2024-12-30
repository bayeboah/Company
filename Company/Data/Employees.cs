using System.ComponentModel.DataAnnotations.Schema;

namespace Company.Data
{
    public class Employees
    {
        public int Id  { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }


        public string Residence { get; set; }

        public string Hometown { get; set; }




        [ForeignKey(nameof(Department))]

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
       



    }
}
