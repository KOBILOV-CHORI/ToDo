namespace Infrastructure.Services;
using Dapper;
using Domain.Dtos;
using Infrastructure.Context;

public class CategoryToDoService
{
    DapperContext dapperContext;
    public CategoryToDoService(DapperContext dapperContext)
    {
        this.dapperContext = dapperContext;
    }
    public int AddCategoryToDo(CategoryToDo _CategoryToDo)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"insert into categories(category_name) values(@CategoryName)";
            var result = conn.Execute(sql, _CategoryToDo);
            return result;
        }
    }
    public CategoryToDo UpdateCategoryToDo(CategoryToDo _CategoryToDo)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"update categories set category_name=@CategoryName where id = @Id";
            conn.Execute(sql, _CategoryToDo);
            return _CategoryToDo;
        }
    }
    public int DeleteCategoryToDo(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"delete from categories where id = @Id";
            var result = conn.Execute(sql, new { id });
            return result;
        }
    }
    public List<CategoryToDo> GetAllCategoryToDo()
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select id Id, category_name CategoryName from categories";
            var result = conn.Query<CategoryToDo>(sql).ToList();
            return result;
        }
    }
    public CategoryToDo GetById(int id)
    {
        using (var conn = dapperContext.CreateConnection())
        {
            var sql = $"select id Id, category_name CategoryName from categories where id = @id";
            var result = conn.QuerySingle<CategoryToDo>(sql, new {id});
            return result;
        }
    }
}
