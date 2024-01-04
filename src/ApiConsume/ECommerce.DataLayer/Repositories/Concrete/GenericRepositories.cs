using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories.Abstract;
using ECommerce.DataAccessLayer.Repositories;
using ECommerce.EntityLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace ECommerce.DataAccessLayer.Repositories.Concretes
{
    public class GenericRepository<T> : IGenericDal<T> where T : class, IEntity
    {
        private readonly Context _context;

        public GenericRepository(Context context)
        {
            _context = context;
        }
        public void Add(T t)
        {
            _context.Set<T>().Add(t);
            _context.SaveChanges();
         
        }
        public void AddRange(List<T> list)
        {
            _context.Set<T>().AddRange();
            _context.SaveChanges();
        }
        public void Delete(T t)
        {
            t.Status = EntityLayer.Enums.DataStatus.Pasif;
            t.DeletedDate = DateTime.Now;
            _context.SaveChanges();
        }
        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }
        public void Destroy(T t)
        {
            _context.Set<T>().Remove(t);
            _context.SaveChanges();
        }
        public void DestroyRange(List<T> list)
        {
            _context.Set<T>().RemoveRange(list);
            _context.SaveChanges();
        }
        public async Task<bool> AnyAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().AnyAsync(exp);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> exp)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(exp);
        }
        public List<T> GetActives()
        {
            return Where(x => x.Status != EntityLayer.Enums.DataStatus.Pasif).ToList();
        }
        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public List<T> GetModifieds()
        {
            return Where(x=>x.Status == EntityLayer.Enums.DataStatus.Güncellendi).ToList();
        }
        public List<T> GetPassives()
        {
            return Where(x => x.Status == EntityLayer.Enums.DataStatus.Pasif).ToList();
        }
        public IQueryable<X> Select<X>(Expression<Func<T, X>> exp)
        {
            return _context.Set<T>().Select(exp);
        }
        public void Update(T item)
        {           
            //item.CreatedDate = default(DateTime);
            item.Status = EntityLayer.Enums.DataStatus.Güncellendi;
            item.ModifiedDate = DateTime.Now;          
            _context.Update(item);
            _context.SaveChanges();         
        }
        public void UpdateRange(List<T> list)
        {
            foreach (T item in list) Update(item);
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> exp)
        {
            return _context.Set<T>().Where(exp);
        }
        public async Task AddAsync(T t)
        {
            await _context.Set<T>().AddAsync(t);
            await _context.SaveChangesAsync();
        }
        public void GetActive(T t)
        {   
            t.Status = EntityLayer.Enums.DataStatus.Aktif;
            t.ModifiedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public async Task<T> FindAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
