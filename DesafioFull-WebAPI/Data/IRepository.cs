using System.Threading.Tasks;
using DesafioFull_WebAPI.Models;

namespace DesafioFull_WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //DIVIDA
        Task<Divida[]> GetAllDividasAsync(bool includeProfessor);        
        Task<Divida> GetDividaAsyncById(int dividaId, bool includeParcelas);
        
    }
}