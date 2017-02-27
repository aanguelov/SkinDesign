using System.ComponentModel.DataAnnotations;

namespace SkinDesign.Entities
{
    public class Procedure
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
