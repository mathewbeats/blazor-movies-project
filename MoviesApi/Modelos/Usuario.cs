﻿using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Modelos
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NombreDeUsuario { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }


    }
}
