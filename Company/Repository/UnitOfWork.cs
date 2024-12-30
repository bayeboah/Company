using Company.Data;
using Company.Irepository;

namespace Company.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        private IGenericRepository<Department> _Departments;
        private IGenericRepository<Employees> _Employees;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }
        public IGenericRepository<Department> Departments => _Departments ??= new GenericRepository<Department>(_context);

        public IGenericRepository<Employees> Employees => _Employees ??= new GenericRepository<Employees>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
