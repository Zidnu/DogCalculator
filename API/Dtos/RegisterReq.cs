using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class RegisterReq
    {
        [Required(ErrorMessage = "Käyttäjänimi on pakollinen")]
        public required string UserName { get; set ; }
        
        [Required(ErrorMessage = "Salasana on pakollinen")]
        public required string Password { get; set; }
    }
}