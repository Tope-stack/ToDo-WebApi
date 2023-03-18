using Microsoft.AspNetCore.Mvc;
using ToDo.Models;
using ToDo.Models.Dtos;
using ToDo.Services;

namespace ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodoController : Controller
    {
        protected readonly ResponseDto _response;
        private readonly ITodoService _todoService;
        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
            this._response = new ResponseDto(); 
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<TodoDto> todoDto = await _todoService.GetTodoItems();
                _response.Result = todoDto;
            } 
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }
            
            return _response;
        }

        [HttpPost]
        public async Task<object> Create([FromBody] TodoDto itemDto)
        {
            try
            {
                TodoDto model = await _todoService.AddUpdateTodoItem(itemDto);
                _response.Result = model;
            } 
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<object> Update([FromBody] TodoDto itemDto)
        {
            try
            {
                TodoDto model = await _todoService.AddUpdateTodoItem(itemDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<object> GetById(int id)
        {
            try
            {
                TodoDto todoDto = await _todoService.GetTodoItemById(id);
                _response.Result = todoDto;
            } 
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }



        [HttpDelete]
        [Route("{id:int}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSucces = await _todoService.DeleteTodoItem(id);
                _response.Result = isSucces;
            }
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }

        [HttpGet]
        [Route("completed")]
        public async Task<object> GetCompleted(bool isCompleted)
        {
            try
            {
                IEnumerable<TodoDto> todoDto = await _todoService.GetCompletedTodoItem(isCompleted);
                _response.Result = todoDto;
            } 
            catch(Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessage = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}
