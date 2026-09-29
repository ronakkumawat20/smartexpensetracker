using System.Xml;
using SET.Entity;

namespace SET.Repository.Interface
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetAll();
        Task<Expense> GetById(Guid id);
        Task<Expense> Add(Expense expense);
        Task<Expense> Update(Expense expense);
    }
}
