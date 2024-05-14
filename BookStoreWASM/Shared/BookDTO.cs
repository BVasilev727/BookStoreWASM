#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreWASM.Shared
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public decimal Price { get; set; }
        public string BookDescription { get; set; }
        public int Quantity { get; set; }
        public string CoverLink { get; set; }
        public string UserName { get; set; }
        public string Genres { get; set; }
    }
}
