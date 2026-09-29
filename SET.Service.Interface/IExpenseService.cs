using SET.Models;

namespace SET.Service.Interface
{
    public interface IExpenseService
    {
        Task<List<ExpenseViewModel>> GetAll();
        Task<ExpenseViewModel> GetById(Guid uniqueId);
        Task<bool> Add(ExpenseViewModel expenseViewModel);
        Task<bool> Update(ExpenseViewModel expenseViewModel);
        Task<bool> Delete(Guid uniqueId);
    }
}
