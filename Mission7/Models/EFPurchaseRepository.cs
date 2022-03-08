using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext context;

        public EFPurchaseRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Purchase> Purchase => context.Purchases.Include(x => x.Lines) ;

        public void SavePurchase(Purchase purchase)
        {
            throw new NotImplementedException();
        }
    }
}
