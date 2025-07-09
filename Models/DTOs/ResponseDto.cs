namespace ToDoListAPI.Models.DTOs
{
    public class ResponseDto
    {
        public bool Success{get;set;} = true;
        public string? ErrorMessage {get;set;}
    }
}