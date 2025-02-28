namespace Todododododododo.Models;

public class UpdateTodoDto
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public bool IsCompleted { get; set; } = false;
}