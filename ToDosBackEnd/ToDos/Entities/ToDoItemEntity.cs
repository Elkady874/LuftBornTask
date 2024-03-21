using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDos.Entities
{
    [Table("ToDoItem")]

    public class ToDoItemEntity
    {
        [Key]
        public int Id { get; set; }
       
        [Required]
        public string Description { get; set; }
   
        [Required]
        public bool Done { get; set; }
 
        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }
}
