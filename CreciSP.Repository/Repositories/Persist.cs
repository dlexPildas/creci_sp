using CreciSP.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreciSP.Repository.Repositories
{
    public class Persist : IPersist
    {
        private readonly DataContext _dataContext;

        public Persist(DataContext dataContext)
        {
            _dataContext = dataContext;

        }

        public void Add<T>(T entity) where T : class
        {
            _dataContext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _dataContext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _dataContext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _dataContext.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _dataContext.SaveChangesAsync()) > 0;
        }
    }
}
