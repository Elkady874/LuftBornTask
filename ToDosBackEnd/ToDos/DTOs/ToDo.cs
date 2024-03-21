using System.ComponentModel.DataAnnotations;

namespace ToDos.DTOs
{
    public class ToDo
    {
         public int Id { get; set; }

         public string Description { get; set; }

      
        public bool Done { get; set; }

         public DateTime CreatedOn { get; set; } 
    }
}
