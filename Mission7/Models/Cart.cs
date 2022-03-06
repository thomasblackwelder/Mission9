using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7.Models
{
    public class Cart
    {
        public List<CartLineItem> Items { get; set; } = new List<CartLineItem>();

        public virtual void AddItem (Book B, int qty)
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

        public virtual void RemoveItem (Book B)
        {
            // go to the <list> of books
            // look in the list to see which books match the book ID and remove those. 
            Items.RemoveAll(x => x.Book.BookId == B.BookId);
        }

        public virtual void ClearCart()
        {
            Items.Clear();
        }

        public double CalculateTotal()
        {
            double sum = Items.Sum(x => x.Book.Price);

            return sum;
        }
    }



    public class CartLineItem
    {
        [Key]
        public int LineID { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

    }
}
