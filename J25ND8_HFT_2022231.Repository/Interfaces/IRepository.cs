using J25ND8_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J25ND8_HFT_2022231.Repository.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Create(T item);
        T Read(int id);
        IQueryable<T> ReadAll();
        void Update(T item);
        void Delete(int id);
        
    }
}
