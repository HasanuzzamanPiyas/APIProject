using System.ComponentModel.DataAnnotations;

namespace APIProject.Model

{
    public class ListModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
