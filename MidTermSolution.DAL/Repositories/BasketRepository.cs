using MidTermSolution.Contracts.Data;
using MidTermSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTermSolution.Contracts.Repositories
{
    public class BasketRepository : RepositoryBase<Basket>
    {
        public BasketRepository(DataContext context)
            : base(context)
        {
            if (context == null)
            {
                throw new ArgumentNullException();
            }
        }
    }

}
