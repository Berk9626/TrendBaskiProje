using ECommerce.EntityLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Repositories.Abstract
{
    public interface IGenericService<T> where T : class, IEntity
    {
        //List Commands
        List<T> GetAll();
        List<T> GetActives();
        List<T> GetModifieds();
        List<T> GetPassives();

        //Modify Commands
        void Add(T t);
        Task AddAsync(T t);
        void AddRange(List<T> list);
        void Update(T item);
        void UpdateRange(List<T> list);
        void GetActive(T t);
        void Delete(T t);
        void DeleteRange(List<T> list);
        void Destroy(T t); //Todo: RemoveAsync varsa metodu Task'e cevirelim
        void DestroyRange(List<T> list);

        //Find Command
        T GetById(int id);
        Task<T> FindAsync(int id);

        //Linq Commands
        IQueryable<T> Where(Expression<Func<T, bool>> exp);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp);
        IQueryable<X> Select<X>(Expression<Func<T, X>> exp);

    }
}
