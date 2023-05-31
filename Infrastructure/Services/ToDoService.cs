namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class ToDoService
{
    DapperContext dapperContext;
    public ToDoService(DapperContext dapperContext)
    {
        this.dapperContext = dapperContext;
    }
    public int AddToDo(ToDoDto _toDoDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into todo(task_name, description, created_at, notification, dedline, status, category_id) values(@Title, @Description, @CreatedAt, @Notification, @DedLine, @Status, @CategoryId)";
            var result = conn.Execute(sql, _toDoDto);
            return result;
        }
    }
    public ToDoDto UpdateToDo(ToDoDto _toDoDto)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update todo set task_name=@Title, description=@Description, created_at=@CreatedAt, notification=@Notification, dedline=@DedLine, status=@Status, category_id=@CategoryId where id = @Id";
            conn.Execute(sql, _toDoDto);
            return _toDoDto;
        }
    }
    public int DeleteToDo(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from todo where id = @Id";
            var result = conn.Execute(sql, new { id });
            return result;
        }
    }
    public List<ToDoDto> GetAllToDo()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select id Id, task_name Title, description Description, created_at CreatedAt, notification Notification, dedline DedLine, status Status, category_id CategoryId from todo";
            var result = conn.Query<ToDoDto>(sql).ToList();
            return result;
        }
    }
    public ToDoDto GetById(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select id Id, task_name Title, description Description, created_at CreatedAt, notification Notification, dedline DedLine, status Status, category_id CategoryId from todo where id = @id";
            var result = conn.QuerySingle<ToDoDto>(sql, new {id});
            return result;
        }
    }
}
