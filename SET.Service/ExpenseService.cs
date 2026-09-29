using System.Xml;
using Microsoft.VisualBasic;
using SET.Entity;
using SET.Models;
using SET.Repository.Interface;
using SET.Service.Interface;

namespace SET.Service
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<bool> Add(ExpenseViewModel expenseViewModel)
        {
            Expense expense = new()
            {
                UniqueId = Guid.NewGuid(),
                Title = expenseViewModel.Title,
                Amount = expenseViewModel.Amount,
                Category = expenseViewModel.Category,
                Description = expenseViewModel.Description,
                ExpenseDate = DateTime.Now,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                IsDeleted = false
            };

            var newExpense = await _expenseRepository.Add(expense);

            if (newExpense != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(Guid uniqueId)
        {
            Expense expense = await _expenseRepository.GetById(uniqueId);
            if (expense == null) return false;

            expense.IsDeleted = true;
            expense.ModifiedDate = DateTime.Now;

            var updatedExpense = await _expenseRepository.Update(expense);

            if (updatedExpense != null)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ExpenseViewModel>> GetAll()
        {
            var expenses = await _expenseRepository.GetAll();

            List<ExpenseViewModel> expenseList = new();

            foreach (var expense in expenses)
            {
                expenseList.Add(new ExpenseViewModel
                {
                    UniqueId = expense.UniqueId,
                    Title = expense.Title,
                    Amount = expense.Amount,
                    Category = expense.Category,
                    Description = expense.Description
                });
            }

            return expenseList;
        }

        public async Task<ExpenseViewModel> GetById(Guid uniqueId)
        {
            var expense = await _expenseRepository.GetById(uniqueId);
            if (expense == null) return null!;

            ExpenseViewModel expenseViewModel = new()
            {
                UniqueId = expense.UniqueId,
                Title = expense.Title,
                Amount = expense.Amount,
                Category = expense.Category,
                Description = expense.Description
            };

            return expenseViewModel;
        }

        public async Task<bool> Update(ExpenseViewModel expenseViewModel)
        {
            Expense expense = await _expenseRepository.GetById(expenseViewModel.UniqueId);
            if (expense == null) return false;

            expense.Title = expenseViewModel.Title;
            expense.Amount = expenseViewModel.Amount;
            expense.Category = expenseViewModel.Category;
            expense.Description = expenseViewModel.Description;
            expense.ModifiedDate = DateTime.Now;

            var updatedExpense = await _expenseRepository.Update(expense);

            if (updatedExpense != null)
            {
                return true;
            }
            return false;
        }
    }
}
