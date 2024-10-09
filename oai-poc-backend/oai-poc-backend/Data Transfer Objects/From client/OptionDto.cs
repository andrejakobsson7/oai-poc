using System.ComponentModel.DataAnnotations;

namespace oai_poc_backend.Data_Transfer_Objects
{
    public class OptionDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(1, ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; } = null!;

        public string? DetailedDescription { get; set; }

        [Required(ErrorMessage = "Category name for option is required")]
        [MinLength(1, ErrorMessage = "Category name for option cannot be empty")]
        public string CategoryName { get; set; } = null!;


    }
}
