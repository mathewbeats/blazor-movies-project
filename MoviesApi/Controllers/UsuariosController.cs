using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Modelos;
using MoviesApi.Modelos.Dtos;
using MoviesApi.Services.IServices;
using System.Net;

namespace MoviesApi.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class Usuarioscontroller : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        private readonly IMapper _mapper;

        protected RespuestasApi _respuestaApi;

        public Usuarioscontroller(IUsuarioRepositorio usuarioRepositorio, IMapper mapper)
        {
            _usuarioRepositorio = usuarioRepositorio;

            _mapper = mapper;

            this._respuestaApi = new RespuestasApi();
        }

        //metodos o endpoints de la api por si el estudiante quiere usarlos
        //no se usaran en el consumo de la api en blazor webassembly
        [Authorize]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult GetUsuario()
        {
            var listaDeUsuarios = _usuarioRepositorio.GetUsuarios();

            var listaDeUsuariosDto = new List<Usuario>();

            foreach (var usuario in listaDeUsuarios)
            {
                listaDeUsuariosDto.Add(_mapper.Map<Usuario>(usuario));
            }

            return Ok(listaDeUsuariosDto);
        }


        //metodos o endpoints de la api por si el estudiante quiere usarlos
        //no se usaran en el consumo de la api en blazor webassembly
        [Authorize]
        [HttpGet("{usuarioId:int}", Name = "GetUsuario")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetUsuario(int usuarioId)
        {
            var itemUsuario = _usuarioRepositorio.GetUsuario(usuarioId);

            if (itemUsuario == null)
            {
                return NotFound();
            }

            var itemUsuarioDto = _mapper.Map<Usuario>(itemUsuario);

            return Ok(itemUsuarioDto);
        }


        [HttpPost("registro")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Registro([FromBody] UsuarioRegistroDto usuarioRegistroDto)
        {
            bool validarNombreDeUsuario = _usuarioRepositorio.IsUniqueUser(usuarioRegistroDto.NombreDeUsuario);

            if (!validarNombreDeUsuario)
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.Errors.Add("El nombre de usuario ya existe");
                return BadRequest();
            }

            var usuario = await _usuarioRepositorio.Registro(usuarioRegistroDto);

            if (usuario == null)
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.Errors.Add("Error en el registro");
                return BadRequest(_respuestaApi);
            }

            _respuestaApi.StatusCode = HttpStatusCode.OK;
            _respuestaApi.IsSuccess = true;
            return Ok(_respuestaApi);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Login([FromBody] UsuarioLoginDto loginDto)
        {
            var respuestaLogin = await _usuarioRepositorio.Login(loginDto);

            if (respuestaLogin.Usuario == null || string.IsNullOrEmpty(respuestaLogin.Token))
            {
                _respuestaApi.StatusCode = HttpStatusCode.BadRequest;
                _respuestaApi.IsSuccess = false;
                _respuestaApi.Errors.Add("El nombre de usuario o password son incorrectos");
                return BadRequest(_respuestaApi);
            }

            _respuestaApi.StatusCode = HttpStatusCode.OK;
            _respuestaApi.IsSuccess = true;
            _respuestaApi.Result = respuestaLogin;
            return Ok(_respuestaApi);
        }

    }
}
