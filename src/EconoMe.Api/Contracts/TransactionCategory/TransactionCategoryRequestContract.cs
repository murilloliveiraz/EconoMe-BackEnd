using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EconoMe.Api.Contracts.TransactionCategory
{
    public class TransactionCategoryRequestContract
    {
        public string Description { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
    }
}