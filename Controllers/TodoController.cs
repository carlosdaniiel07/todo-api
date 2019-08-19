using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

using todo_api.Models;

namespace todo_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController (TodoContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> GetAll ()
        {
            return _context.TodoItems.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<TodoItem> GetById (long id)
        {
            var item = _context.TodoItems.Where(i => i.Id.Equals(id)).FirstOrDefault();

            if (item != null)
            {
                return item;
            }
            
            return NotFound();
        }

        [HttpPost]
        public ActionResult<TodoItem> Insert (TodoItem obj)
        {
            _context.TodoItems.Add(obj);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = obj.Id}, obj);
        }

        [HttpPut("{id}")]
        public ActionResult Update (long id, TodoItem obj)
        {
            if (id.Equals(obj.Id))
            {
                _context.TodoItems.Update(obj);
                _context.SaveChanges();

                return NoContent();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete (long id)
        {
            var item = _context.TodoItems.Where(i => i.Id.Equals(id)).FirstOrDefault();

            if (item != null)
            {
                _context.TodoItems.Remove(item);
                _context.SaveChanges();

                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}