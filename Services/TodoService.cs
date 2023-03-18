using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ToDo.DataContext;
using ToDo.Models;
using ToDo.Models.Dtos;
using ToDo.Utilities;

namespace ToDo.Services
{
    public class TodoService : ITodoService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TodoService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TodoDto> AddUpdateTodoItem(TodoDto item)
        {
            Todo todo = _mapper.Map<TodoDto, Todo>(item);   

            if (todo.Id != 0)
            {
                _context.todos.Update(todo);
            } 
            else
            {
                _context.todos.Add(todo);   
            }

            await _context.SaveChangesAsync();
            return _mapper.Map<Todo, TodoDto>(todo);
        }

        public async Task<bool> DeleteTodoItem(int id)
        {
            Todo todo = await _context.todos.FirstOrDefaultAsync(x => x.Id == id);

            if (todo == null) return false;

            _context.todos.Remove(todo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<TodoDto>> GetCompletedTodoItem(bool isCompleted)
        {
            IEnumerable<Todo> todo = await _context.todos.Where(x => x.isCompleted == isCompleted).ToListAsync();

            return _mapper.Map<List<TodoDto>>(todo);
        }

        public async Task<TodoDto> GetTodoItemById(int id)
        {
            Todo todo = await _context.todos.Where(x => x.Id == id).FirstAsync();

            return _mapper.Map<TodoDto>(todo);
        }

        public async Task<IEnumerable<TodoDto>> GetTodoItems()
        {
            IEnumerable<Todo> todo = await _context.todos.ToListAsync();

            return _mapper.Map <List<TodoDto>>(todo);
        }

      

        //public async Task<TodoDto> UpdateTodoItem(TodoDto item, int id)
        //{
        //    var existingItem = await _context.todos.FirstOrDefaultAsync(x => x.Id == id);

        //    existingItem.Name = item.Name;
        //    existingItem.isCompleted = item.isCompleted;

        //    await _context.SaveChangesAsync();

        //    return existingItem;
        //}
    }
}
