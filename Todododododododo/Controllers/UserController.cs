using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Todododododododo.Data;
using Todododododododo.Models;
using Todododododododo.Models.Entities;

namespace Todododododododo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public UserController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Users>> Post(CreateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = new Users()
            {
                Username = user.Username,
                Email = user.Email,
                // not in the mood to implement hashing so just save raw passwords for now. 
                PasswordHash = user.Password,
                CreatedAt = DateTime.UtcNow,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = newUser.Id }, newUser);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UpdateUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userToUpdate = await _context.Users.FindAsync(id);

            if (userToUpdate == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(user.Username) && userToUpdate.Username != user.Username)
            {
                userToUpdate.Username = user.Username;
            }

            if (!string.IsNullOrEmpty(user.Email) && userToUpdate.Email != user.Email)
            {
                userToUpdate.Email = user.Email;
            }

            // as of now passwords are raw not hashed
            if (!string.IsNullOrEmpty(user.Password) && userToUpdate.PasswordHash != user.Password)
            {
                userToUpdate.PasswordHash = user.Password;
            }


            _context.Entry(userToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Users>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }
            
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}