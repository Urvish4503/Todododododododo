using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        
        // TODO: create new user
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
            
            return CreatedAtAction(nameof(Getus));
        }
        
        // TODO: get user by id
        [HttpGet]
        
        
        // TODO: edit user
        
        // TODO: delete user
    }
}
