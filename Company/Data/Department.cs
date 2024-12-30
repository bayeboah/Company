using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Company.Data
{
    public class Department
    {
        public  int Id { get; set; }
        
        public string DepartmentName { get; set; }

        public string ShortName { get; set; }

        //public string Description { get; set; }

        //Employees in a deparment
        public virtual IList<Employees> Employees { get; set; }

    }
}
