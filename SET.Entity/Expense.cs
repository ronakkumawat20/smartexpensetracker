using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SET.Entity
{
    public  class Expense : BaseEntity
    {
        public required string Title { get; set; }
        public string? Description { get; set; }
        public required decimal Amount { get; set; }
        public required string Category { get; set; }
        public DateTime ExpenseDate { get; set; }
        public bool IsRecurring { get; set; }
    }
}
