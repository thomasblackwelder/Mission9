using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public interface IPurchaseRepository // this is acting as a template ("interface") from which to build the repo
    {
        IQueryable<Purchase> Purchase { get; }

        void SavePurchase(Purchase purchase);
    }
}
