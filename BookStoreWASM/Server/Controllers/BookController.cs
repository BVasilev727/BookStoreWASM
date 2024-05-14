#nullable disable
using BookStoreWASM.Server.Data;
using BookStoreWASM.Server.Models;
using BookStoreWASM.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWASM.Server.Controllers
{

    [Authorize]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookStoreLibraryContext _context;

        public BookController(BookStoreLibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/Book/GetAsync")]
        public async Task<List<BookDTO>> GetAsync()
        {
            var result = await _context.Books.AsNoTracking().ToListAsync();

            List<BookDTO> ColBooks = new List<BookDTO>();

            foreach (var item in result)
            {
                BookDTO objBook = new BookDTO();
                objBook.BookId = item.BookId;
                objBook.Title = item.Title;
                objBook.CoverLink = item.CoverLink;
                objBook.Author = item.Author;
                objBook.UserName = item.UserName;
                objBook.Quantity = item.Quantity;
                objBook.Price = item.Price;
                objBook.Genres = item.Genres;
                objBook.BookDescription = item.BookDescription;
                
                ColBooks.Add(objBook);
            }
            return ColBooks;
        }

        [HttpGet]
        [Route("api/Book/GetBook/{id}")]
        public async Task<BookDTO> GetBook(int id)
        {
            BookDTO foundBook = new BookDTO();
            var book = _context.Books.Where(b => b.BookId == id).FirstOrDefault();
            if(book != null)
            {
                foundBook.BookId = book.BookId;
                foundBook.Title = book.Title;
                foundBook.CoverLink = book.CoverLink;
                foundBook.Author = book.Author;
                foundBook.UserName = book.UserName;
                foundBook.Quantity = book.Quantity;
                foundBook.Price = book.Price;
                foundBook.Genres = book.Genres;
                foundBook.BookDescription = book.BookDescription;
                return foundBook;
            }
            return null;
        }

        [HttpPost]
        [Route("api/Book/Post")]
        public void Post([FromBody] BookDTO paramBook)
        {
            Book objBook = new Book();


            objBook.BookId = paramBook.BookId;
            objBook.Title = paramBook.Title;
            objBook.CoverLink = paramBook.CoverLink;
            objBook.Author = paramBook.Author;
            objBook.Quantity = paramBook.Quantity;
            objBook.Price = paramBook.Price;
            objBook.Genres = paramBook.Genres;
            objBook.BookDescription = paramBook.BookDescription;

            _context.Books.Add(objBook);
            _context.SaveChanges();
        }

        [HttpPut]
        [Route("api/Book/Put")]
        public void Put([FromBody] BookDTO objBook)
        {
            string currUser = this.User.Claims.Where(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")
                .FirstOrDefault().Value;

            var ExistingBook = _context.Books.
                Where(x => x.BookId == objBook.BookId).FirstOrDefault();

            if(ExistingBook!=null)
            {
                ExistingBook.BookId = objBook.BookId;
                ExistingBook.Author = objBook.Author;
                ExistingBook.Title = objBook.Title;
                ExistingBook.UserName = currUser;
                ExistingBook.Quantity = objBook.Quantity;
                ExistingBook.Price = objBook.Price;
                ExistingBook.CoverLink = objBook.CoverLink;
                ExistingBook.Genres = objBook.Genres;
                ExistingBook.BookDescription= objBook.BookDescription;
                _context.SaveChanges();
            }
        }
        [HttpDelete]
        [Route("api/Book/Delete/{id}")]
        public void Delete(int id)
        {
            var ExistingBook = _context.Books.
                Where(x => x.BookId == id).FirstOrDefault();

            if(ExistingBook!=null) {
                _context.Remove(ExistingBook);
                _context.SaveChanges();
            }
        }
    }
}
