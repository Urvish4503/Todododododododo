using Humanizer;
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
    public class TodoController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TodoController(ApplicationDBContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Todos>> Post(CreateTodoDto todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTodo = new Todos()
            {
                Title = todo.Title,
                Content = todo.Content,
                CreatedAt = DateTime.UtcNow,
                UserId = todo.UserId,
                IsCompleted = false,
            };

            _context.Todos.Add(newTodo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTodoById), new { id = newTodo.Id }, newTodo);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Todos>>> GetTodosByUserId(int userId)
        {
            var todo = await _context.Todos.Where(t => t.UserId == userId).ToListAsync();


            return Ok(todo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todos>> GetTodoById(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UpdateTodoDto todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var todoToUpdate = await _context.Todos.FindAsync(id);

            if (todoToUpdate == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(todo.Title) && todoToUpdate.Title != todo.Title)
            {
                todoToUpdate.Title = todo.Title;
            }

            if (todo.Content != todoToUpdate.Content)
            {
                todoToUpdate.Content = todo.Content;
            }

            if (todo.IsCompleted != todoToUpdate.IsCompleted)
            {
                todoToUpdate.IsCompleted = todo.IsCompleted;
            }

            _context.Entry(todoToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Todos>> DeleteTodo(int id)
        {
            var todo = await _context.Todos.FindAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}