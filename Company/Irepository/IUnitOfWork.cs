using Company.Data;

namespace Company.Irepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Department> Departments { get; }

        IGenericRepository<Employees> Employees { get; }


        Task save();
    }
}
