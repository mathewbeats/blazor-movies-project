using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Modelos.Dtos
{
    public class UsuarioRegistroDto
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreDeUsuario { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El password es obligatorio")]
        public string Password { get; set; }
    }
}
