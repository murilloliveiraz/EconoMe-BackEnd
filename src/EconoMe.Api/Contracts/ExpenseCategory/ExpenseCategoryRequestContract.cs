using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EconoMe.Api.Contracts.ExpenseCategory
{
    public class ExpenseCategoryRequestContract
    {
        public string Description { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}