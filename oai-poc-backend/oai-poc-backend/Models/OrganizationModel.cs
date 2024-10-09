using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class OrganizationModel
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; } = null!;

        [Column("organization_number")]
        public long OrganizationNumber { get; set; }

        //Navigation properties
        public List<ApplicationUser>? Users { get; set; } = new();
        public List<ProductModel> Products { get; set; } = new();
    }
}
