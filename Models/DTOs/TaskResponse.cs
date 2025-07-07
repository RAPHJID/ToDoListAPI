using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models.DTOs
{
    public class TaskResponse
    {
        public Guid Id {get;set;}
        public string Title {get;set}
        public bool IsCompleted {get;set;}
        public DateTime? DueDate {get;set;}   
    }
}