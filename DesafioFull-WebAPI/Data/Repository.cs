using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DesafioFull_WebAPI.Models;

namespace DesafioFull_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Divida[]> GetAllDividasAsync(bool includeParcelas = false)
        {
            IQueryable<Divida> query = _context.Dividas;

            if (includeParcelas)
            {
                query = query.Include(d => d.Parcelas);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Divida> GetDividaAsyncById(int dividaId, bool includeParcelas = false)
        {
            IQueryable<Divida> query = _context.Dividas;

            if (includeParcelas)
            {
                query = query.Include(d => d.Parcelas);
            }

            query = query.AsNoTracking()
                         .OrderBy(d => d.Id)
                         .Where(d => d.Id == dividaId);

            return await query.FirstOrDefaultAsync();
        }
    }
}