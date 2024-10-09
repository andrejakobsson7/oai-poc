using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace oai_poc_backend.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Column("organization_id")]
        public int OrganizationId { get; set; }

        //Navigation properties
        public OrganizationModel Organization { get; set; } = null!;
    }
}
