using ECommerce.BusinessLayer.Repositories.Abstract;
using ECommerce.DataAccessLayer.Repositories.Abstract;
using ECommerce.EntityLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Repositories.Concrete
{
    public class BaseManager<T> : IGenericService<T> where T : class, IEntity
    {
        protected IGenericDal<T> _igp;
        public BaseManager(IGenericDal<T> igp)
        {
            _igp = igp;
        }

        public void Add(T t)
        {
            _igp.Add(t);
        }

        public async Task AddAsync(T t)
        {
            await _igp.AddAsync(t);
        }

        public void AddRange(List<T> list)
        {
            _igp.AddRange(list);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _igp.AnyAsync(exp);
        }

        public void GetActive(T t)
        {
            _igp.GetActive(t);
        }

        public void Delete(T t)
        {
            _igp.Delete(t);
        }

        public void DeleteRange(List<T> list)
        {
            _igp.DeleteRange(list);
        }

        public void Destroy(T t)
        {
            _igp.Destroy(t);
        }

        public void DestroyRange(List<T> list)
        {
            _igp.DestroyRange(list);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _igp.FirstOrDefaultAsync(exp);
        }

        public List<T> GetActives()
        {
            return _igp.GetActives();
        }

        public List<T> GetAll()
        {
            return _igp.GetAll();
        }

        public T GetById(int id)
        {
            return _igp.GetById(id);
        }

        public List<T> GetModifieds()
        {
            return _igp.GetModifieds();
        }

        public List<T> GetPassives()
        {
            return _igp.GetPassives();
        }

        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _igp.Select(exp);
        }

        public void Update(T item)
        {
            _igp.Update(item);
        }

        public void UpdateRange(List<T> list)
        {
            _igp.UpdateRange(list);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _igp.Where(exp);
        }

        public async Task<T> FindAsync(int id)
        {
            return await _igp.FindAsync(id);
        }
    }
}
