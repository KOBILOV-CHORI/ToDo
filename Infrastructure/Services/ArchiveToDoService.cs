namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class ArchiveToDoService
{
    DapperContext dapperContext;
    public ArchiveToDoService(DapperContext dapperContext)
    {
        this.dapperContext = dapperContext;
    }
    public int AddArchiveToDo(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql1 = $"select task_name Title, description Description, created_at CreatedAt, notification Notification, dedline DedLine, status Status, category_id CategoryId from todo where id = @id";
            var _archiveToDo = conn.Query<ArchiveToDo>(sql1, new { id });

            var sql2 = $"insert into archive(task_name, description, created_at, notification, dedline, status, category_id) values(@Title, @Description, @CreatedAt, @Notification, @DedLine, @Status, @CategoryId)";
            var result = conn.Execute(sql2, _archiveToDo);

            var sql3 = $"delete from todo where id = @id";
            conn.Execute(sql3, id);
            return result;
        }
    }
    public int GetArchiveToDo(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql1 = $"select id Id, task_name Title, description Description, created_at CreatedAt, notification Notification, dedline DedLine, status Status, category_id CategoryId from archive where id = @id";
            var _archiveToDo = conn.Query<ArchiveToDo>(sql1, new { id });

            var sql2 = $"insert into todo(task_name, description, created_at, notification, dedline, status, category_id) values(@Title, @Description, @CreatedAt, @Notification, @DedLine, @Status, @CategoryId)";
            var result = conn.Execute(sql2, _archiveToDo);

            var sql3 = $"delete from archive where id = @id";
            conn.Execute(sql3, new { id });
            return result;
        }
    }
    public int DeleteToDo(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from archive where id = @Id";
            var result = conn.Execute(sql, new { id });
            return result;
        }
    }
    public List<ArchiveToDo> GetAllArchiveToDo()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select id Id, task_name Title, description Description, created_at CreatedAt, notification Notification, dedline DedLine, status Status, category_id CategoryId from archive";
            var result = conn.Query<ArchiveToDo>(sql).ToList();
            return result;
        }
    }
    public ArchiveToDo GetById(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select id Id, task_name Title, description Description, created_at CreatedAt, notification Notification, dedline DedLine, status Status, category_id CategoryId from archive where id = @id";
            var result = conn.QuerySingle<ArchiveToDo>(sql, new { id });
            return result;
        }
    }
}
