namespace Domain.Dtos;

public class ToDoDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime Notification { get; set; }
    public DateTime DedLine { get; set; }
    public string? Status { get; set; }
    public int CategoryId { get; set; }
}
