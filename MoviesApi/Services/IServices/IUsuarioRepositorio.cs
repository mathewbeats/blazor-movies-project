using MoviesApi.Modelos;
using MoviesApi.Modelos.Dtos;

namespace MoviesApi.Services.IServices
{
    public interface IUsuarioRepositorio
    {
        ICollection<Usuario> GetUsuarios();

        Usuario GetUsuario(int UsuarioId);

        bool IsUniqueUser(string usuario);

        Task<UsuarioLoginRespuestaDto> Login(UsuarioLoginDto usuarioLoginDto);

        Task<Usuario> Registro(UsuarioRegistroDto usuarioRegristroDto);
    }
}
