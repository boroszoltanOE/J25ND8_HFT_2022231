using J25ND8_HFT_2022231.Models;
using J25ND8_HFT_2022231.Repository.Data;
using J25ND8_HFT_2022231.Repository.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Repository.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected AirPortDbContext ctx;
        public Repository(AirPortDbContext ctx)
        {
            this.ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
        }

        public void Create(T item)
        {
            ctx.Set<T>().Add(item);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
            ctx.SaveChanges();
        }

        public T Read(int id)
        {
            return ctx.Set<T>().FirstOrDefault(item => item.Id.Equals(id));
        }

        public IQueryable<T> ReadAll()
        {
            return ctx.Set<T>();
        }

        public void Update(T item)
        {
            var updateNeed = Read(item.Id);
            foreach (var property in updateNeed.GetType().GetProperties())
            {
                if (property.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    property.SetValue(updateNeed, property.GetValue(item));
                }
            }
            ctx.SaveChanges();
        }
    }
}
