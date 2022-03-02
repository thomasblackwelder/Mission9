using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public void AddItem (Book B, int qty)
        {
            CartLineItem line = Items
                .Where(b => b.Book.BookId == B.BookId)
                .FirstOrDefault();

            if(line == null)
            {
                Items.Add(new CartLineItem
                {
                    Book = B,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Book.Price);

            return sum;
        }
    }



    public class CartLineItem
    {
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
