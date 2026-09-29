using System.Xml;
using Microsoft.EntityFrameworkCore;
using SET.Entity;
using SET.Infrastructure;
using SET.Repository.Interface;

namespace SET.Repository
{
    public class ExpenseRepository : IExpenseRepository
    {
        public readonly SetDbContext _context;
        public ExpenseRepository(SetDbContext context)
        {
            _context = context;
        }
        public async Task<Expense> Add(Expense expense)
        {
            await _context.AddAsync(expense);
            await _context.SaveChangesAsync();
            return expense;
        }

        public async Task<List<Expense>> GetAll()
        {
            var expense = await _context.Expense.Where(a => !a.IsDeleted).ToListAsync(); // select * from faq where IsDeleted = 0
            return expense;
        }

        public async Task<Expense> GetById(Guid id)
        {
            var expenses = await _context.Expense.FirstOrDefaultAsync(a => a.UniqueId == id);
            return expenses;
        }

        public async Task<Expense> Update(Expense expense)
        {
            _context.Expense.Update(expense);
            await _context.SaveChangesAsync();
            return expense;
        }
    }
}
