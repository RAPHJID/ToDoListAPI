using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoListAPI.Models
{
    public class Task
    {
        [Key]
        public Guid Id {get;set;}
        [Required, (ErrorMessage = "Title required")]
        [MaxLength(50, ErrorMessage = "Title cannot be more than 50 characters")]
        public string Title {get;set}
        public bool IsCompleted {get;set;} = false;
        public DateTime? DueDate {get;set;}

    }
}