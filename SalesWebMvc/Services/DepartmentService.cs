using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Services.Exceptions;
using MySqlConnector;

namespace SalesWebMvc.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMvcContext _context;

        public DepartmentService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                var department = await _context.Department.FindAsync(id);
                if (department != null)
                {
                    _context.Department.Remove(department);
                    await _context.SaveChangesAsync();
                }

            }
            catch (DbUpdateException)
            {
                throw new DbUpdateException("Can't delete department because he/she has sellers.");
            }
            catch (IntegrityException)
            {
                throw new IntegrityException("Can't delete department because he/she has sellers.");
            }
        }
    }
}
