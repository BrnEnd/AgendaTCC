using SistemaAgendamento.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaAgendamento.Domain.Interfaces
{
    public interface IRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<T> GetById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
