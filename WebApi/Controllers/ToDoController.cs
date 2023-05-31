using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    private ToDoService _toDoService;
    public ToDoController(ToDoService ToDoService)
    {
        _toDoService = ToDoService;
    }
    [HttpPost("Add ToDo")]
    public int Add(ToDoDto _toDoDto)
    {
        return _toDoService.AddToDo(_toDoDto);
    }
    [HttpPut("Update")]
    public ToDoDto Update(ToDoDto _toDoDto)
    {
        return _toDoService.UpdateToDo(_toDoDto);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _toDoService.DeleteToDo(id);
    }
    [HttpGet("Get All")]
    public List<ToDoDto> GetAll()
    {
        return _toDoService.GetAllToDo();
    }
    [HttpGet("Get By Id")]
    public ToDoDto GetById(int id)
    {
        return _toDoService.GetById(id);
    }
}
