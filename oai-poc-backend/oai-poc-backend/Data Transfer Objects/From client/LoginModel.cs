using System.ComponentModel.DataAnnotations;

namespace oai_poc_backend.Data_Transfer_Objects.From_client
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
        public bool RememberMe { get; set; } = false;
    }
}
