using BookStoreWASM.Server.Data;
using BookStoreWASM.Server.Models;
using BookStoreWASM.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWASM.Server.Controllers
{
    [Authorize(Roles ="Administrator")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly BookStoreLibraryContext _context;

        public UserController(BookStoreLibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("api/User/GetAsync")]
        public async Task<List<AspNetUserDTO>> GetAsync()
        {
            var resultUsers = await _context.AspNetUsers.AsNoTracking().ToListAsync();
            var resultRoles = await _context.AspNetRoles.AsNoTracking().ToListAsync();
            
            List<AspNetUserDTO> ColUsers = new List<AspNetUserDTO>();

            foreach (var item in resultUsers)
            {
                AspNetUserDTO user = new AspNetUserDTO();
                user.Id = item.Id;
                user.Name = item.UserName;
                user.Email = item.Email;
                user.Password = "*****";
                
                ColUsers.Add(user);
            }
            return ColUsers;
        }

      
        [HttpDelete]
        [Route("api/User/Delete/{id}")]
        public void Delete(string id)
        {
               var ExistingUser = _context.AspNetUsers.
                Where(x => x.Id == id).FirstOrDefault();

            if (ExistingUser != null)
            {
                _context.Remove(ExistingUser);
                _context.SaveChanges();
            }
        }
    }
}
