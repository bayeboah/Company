using AutoMapper;
using Company.Data;
using Company.Model;

namespace Company.Configuration
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<Department,DepartmentDTO>().ReverseMap();
            CreateMap<Department, CreateDepartmentDTO>().ReverseMap();

            CreateMap<Employees, EmployeesDTO>().ReverseMap();
            CreateMap<Employees, CreateEmployeesDTO>().ReverseMap();

        }
    }
}
