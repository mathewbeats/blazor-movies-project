﻿using System.ComponentModel.DataAnnotations;

namespace BlazorMoviesProject.Models
{
    public class UsuarioAutenticacion
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string NombreDeUsuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
    }
}
