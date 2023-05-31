using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoryToDoController : ControllerBase
{
    private CategoryToDoService _categoryToDoService;
    public CategoryToDoController(CategoryToDoService CategoryToDoService)
    {
        _categoryToDoService = CategoryToDoService;
    }
    [HttpPost("Add CategoryToDo")]
    public int Add(CategoryToDo _categoryToDo)
    {
        return _categoryToDoService.AddCategoryToDo(_categoryToDo);
    }
    [HttpPut("Update")]
    public CategoryToDo Update(CategoryToDo _categoryToDo)
    {
        return _categoryToDoService.UpdateCategoryToDo(_categoryToDo);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return _categoryToDoService.DeleteCategoryToDo(id);
    }
    [HttpGet("Get All")]
    public List<CategoryToDo> GetAll()
    {
        return _categoryToDoService.GetAllCategoryToDo();
    }
    [HttpGet("Get By Id")]
    public CategoryToDo GetById(int id)
    {
        return _categoryToDoService.GetById(id);
    }
}
