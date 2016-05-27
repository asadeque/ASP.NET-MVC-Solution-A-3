using MidTermSolution.Contracts.Data;
using MidTermSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermSolution.Contracts.Repositories
{
    public class BasketItemRepository : RepositoryBase<BasketItem>
    {
        public BasketItemRepository(DataContext context)
            : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }
}
