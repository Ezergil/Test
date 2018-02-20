using System.ComponentModel.DataAnnotations.Schema;

namespace TestProject.Abstraction
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
