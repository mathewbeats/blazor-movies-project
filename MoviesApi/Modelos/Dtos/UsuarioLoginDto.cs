using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Modelos.Dtos
{
    public class UsuarioLoginDto
    {


        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreDeUsuario { get; set; }


        [Required(ErrorMessage = "El password es obligatorio")]
        public string Password { get; set; }
    }
}
