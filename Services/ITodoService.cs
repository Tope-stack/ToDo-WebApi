using ToDo.Models;
using ToDo.Models.Dtos;

namespace ToDo.Services
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoDto>> GetTodoItems();
        Task<IEnumerable<TodoDto>> GetCompletedTodoItem(bool isCompleted);
        Task<TodoDto> GetTodoItemById(int id); 
        Task<TodoDto> AddUpdateTodoItem(TodoDto item);
        //Task<TodoDto> UpdateTodoItem(TodoDto item, int id);
        Task<bool> DeleteTodoItem(int id);
        
    }
}
