using MoviesApi.Data;
using MoviesApi.Modelos;
using MoviesApi.Modelos.Dtos;
using MoviesApi.Services.IServices;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Security.Cryptography;

namespace MoviesApi.Services
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApplicationDbContext _context;

        private string claveSecreta;


        public UsuarioRepositorio(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;

            claveSecreta = config.GetValue<string>("ApiSettings:Secreta");
        }

        public Usuario GetUsuario(int UsuarioId)
        {
            return _context.Usuario.FirstOrDefault(c => c.Id == UsuarioId);
        }

        public ICollection<Usuario> GetUsuarios()
        {
            return _context.Usuario.OrderBy(c => c.Id).ToList();
        }

        public bool IsUniqueUser(string usuario)
        {
            var usuarioBd = _context.Usuario.FirstOrDefault(c => c.NombreDeUsuario == usuario);

            return usuarioBd == null;
        }

        public async Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto)
        {
            var passwordEncriptado = obtenerMd5(usuarioLoginDto.Password);

            var usuario = _context.Usuario.FirstOrDefault(
                u => u.NombreDeUsuario.ToLower() == usuarioLoginDto.NombreDeUsuario.ToLower()
                && u.Password == passwordEncriptado
                );

            //validamos si el usuario no existe con la combinacion de usuario y contraseña

            if (usuario == null)
            {
                return new UsuarioLoginRespuestaDto()
                {
                    Token = "",
                    Usuario = null
                };
            }

            //aqui si existe el usuario entonces podemos procesar el login

            var manejadorToken = new JwtSecurityTokenHandler();
            //aqui añadimos la clave secreta
            var key = Encoding.ASCII.GetBytes(claveSecreta);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.NombreDeUsuario.ToString()),
                    new Claim(ClaimTypes.Email, usuario.Email), // Agregar el claim de correo electrónico
                    new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString())




                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)


            };

            var token = manejadorToken.CreateToken(tokenDescriptor);

            UsuarioLoginRespuestaDto usuarioLoginRespuestaDto = new UsuarioLoginRespuestaDto()
            {
                Token = manejadorToken.WriteToken(token),
                Usuario = usuario
            };

            return usuarioLoginRespuestaDto;

        }



        public async Task<Usuario> Registro(UsuarioRegistroDto usuarioRegristroDto)
        {
            var passwordEncriptada = obtenerMd5(usuarioRegristroDto.Password);

            Usuario usuario = new Usuario()
            {
                NombreDeUsuario = usuarioRegristroDto.NombreDeUsuario,
                Password = passwordEncriptada,
                Nombre = usuarioRegristroDto.Nombre,
                Email = usuarioRegristroDto.Email
            };

            _context.Usuario.Add(usuario);
            usuario.Password = passwordEncriptada;
            await _context.SaveChangesAsync();
            return usuario;
        }




        //metodo para encriptar la contraseña y el password Md5

        public string obtenerMd5(string valor)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(valor);
            data = x.ComputeHash(data);
            string resp = "";
            for (int i = 0; i < data.Length; i++)
            {
                resp = resp + data[i].ToString("x2").ToLower();
            }
            return resp;

        }
    }
}
