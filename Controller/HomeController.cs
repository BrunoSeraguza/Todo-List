using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoList.Data;
using todoList.Models;

namespace todoList.Controller
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Get([FromServices] AppDbContext context)
        => Ok( context.Todos.ToList());
        
        [HttpGet("/{id:int}")]
        public IActionResult GetById([FromServices] AppDbContext context, [FromRoute] int id)                 
        {
           var todo = context.Todos.FirstOrDefault(x => x.Id == id);
           if(todo == null)
                return NotFound();

                return Ok(todo);
        }       
        
        [HttpPost("/")]
        public TodoModel Post([FromServices] AppDbContext context, [FromBody] TodoModel model)
        {
            context.Add<TodoModel>(model);
            context.SaveChanges();

            return model;
        }
        [HttpPut("{id:int}")]
        public IActionResult Put( [FromServices] AppDbContext context, [FromBody] TodoModel todo,[FromRoute]  int id)      
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if(model == null)
              return NotFound();

              model.Tittle = todo.Tittle;
              model.Done = todo.Done;

              context.Todos.Update(model);
              context.SaveChanges();
              return Ok(model);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromServices] AppDbContext context, [FromRoute]  int id)
        {
            var model = context.Todos.FirstOrDefault(x => x.Id == id);
            if(model == null)
                return NotFound();

            context.Todos.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
       
            
    }
}