using Microsoft.AspNetCore.Mvc;
using Infrastructure.Services;
using Domain.Dtos;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ArchiveToDoController : ControllerBase
{
    private ArchiveToDoService archiveToDoService;
    public ArchiveToDoController(ArchiveToDoService ArchiveToDoService)
    {
        this.archiveToDoService = ArchiveToDoService;
    }
    [HttpPost("Add Archive")]
    public int Add(int id)
    {
        return archiveToDoService.AddArchiveToDo(id);
    }
    [HttpGet("Get from Archive")]
    public int Get(int id)
    {
        return archiveToDoService.GetArchiveToDo(id);
    }
    [HttpDelete("Delete")]
    public int Delete(int id)
    {
        return archiveToDoService.DeleteToDo(id);
    }
    [HttpGet("Get All")]
    public List<ArchiveToDo> GetAll()
    {
        return archiveToDoService.GetAllArchiveToDo();
    }
    [HttpGet("Get By Id")]
    public ArchiveToDo GetById(int id)
    {
        return archiveToDoService.GetById(id);
    }
}
