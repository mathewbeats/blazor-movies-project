using Blazored.LocalStorage;
using BlazorMoviesProject.Helpers;
using BlazorMoviesProject.Models;
using BlazorMoviesProject.Services.IServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace BlazorMoviesProject.Services
{
    public class ServicioAutenticacion : IServicioAutenticacion
    {

        private readonly HttpClient _httpClient;

        private readonly ILocalStorageService _localStorageService;

        private readonly AuthenticationStateProvider _estadoProveedorAutenticacion;

        private NavigationManager _navigationManager;




        public ServicioAutenticacion(HttpClient httpClient, ILocalStorageService localStorageService,
            AuthenticationStateProvider estadoProveedorAutenticacion, NavigationManager navigationManager)
        {
            _httpClient = httpClient;

            _localStorageService = localStorageService;

            _estadoProveedorAutenticacion = estadoProveedorAutenticacion;
            _navigationManager = navigationManager;
        }


        public async Task<RespuestaAutenticacion> Acceder(UsuarioAutenticacion usuarioDesdeAutenticacion)
        {
            var content = JsonConvert.SerializeObject(usuarioDesdeAutenticacion);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{Inicializar.UrlBaseApi}api/usuario/login", bodyContent);

            var contentTemp = await response.Content.ReadAsStringAsync();

            var resultado = (JObject)JsonConvert.DeserializeObject(contentTemp);

            if (response.IsSuccessStatusCode)
            {
                var token = resultado["result"]["token"].Value<string>();

                var Usuario = resultado["result"]["usuario"]["nombreDeUsuario"].Value<string>();

                await _localStorageService.SetItemAsync(Inicializar.Token_Local, token);

                await _localStorageService.SetItemAsync(Inicializar.Datos_Usuario_Local, Usuario);

                ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioLogueado(token);

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

                return new RespuestaAutenticacion { IsSuccess = true };

            }
            else
            {
                return new RespuestaAutenticacion { IsSuccess = false };

            }


        }

        public async Task<UusuarioRespuestaRegistro> RegistrarUsuario(UsuarioRegistro usuarioRegistro)
        {
            var content = JsonConvert.SerializeObject(usuarioRegistro);

            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{Inicializar.UrlBaseApi}api/usuario/registro", bodyContent);

            var contentTemp = await response.Content.ReadAsStringAsync();

            var resultado = JsonConvert.DeserializeObject<UusuarioRespuestaRegistro>(contentTemp);

            if (response.IsSuccessStatusCode)
            {


                return new UusuarioRespuestaRegistro { RegistroCorrecto = true };

            }
            else
            {
                return resultado;

            }
        }

        //public async Task Salir()
        //{
        //    Console.WriteLine("Removiendo token y datos de usuario del almacenamiento local...");
        //    await _localStorageService.RemoveItemAsync(Inicializar.Token_Local);
        //    await _localStorageService.RemoveItemAsync(Inicializar.Datos_Usuario_Local);
        //    Console.WriteLine("Tokens removidos. Limpiando encabezados HTTP...");
        //    _httpClient.DefaultRequestHeaders.Authorization = null;
        //    Console.WriteLine($"Encabezado Authorization ahora está configurado como: {_httpClient.DefaultRequestHeaders.Authorization}");

        //    ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioSalir();
        //    Console.WriteLine("Usuario deslogueado y notificado a todos los suscriptores.");
        //}

        public async Task Salir()
        {
            Console.WriteLine("Removiendo token y datos de usuario del almacenamiento local...");
            await _localStorageService.RemoveItemAsync(Inicializar.Token_Local);
            await _localStorageService.RemoveItemAsync(Inicializar.Datos_Usuario_Local);
            Console.WriteLine("Tokens removidos. Limpiando encabezados HTTP...");
            _httpClient.DefaultRequestHeaders.Authorization = null;

            ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioSalir();
            Console.WriteLine("Usuario deslogueado y notificado a todos los suscriptores.");

            // Redirigir al usuario a la página de inicio
            _navigationManager.NavigateTo("/Home", forceLoad: true);
        }





        //public async Task Salir()
        //{
        //    await _localStorageService.RemoveItemAsync(Inicializar.Token_Local);

        //    await _localStorageService.RemoveItemAsync(Inicializar.Datos_Usuario_Local);

        //    ((AuthStateProvider)_estadoProveedorAutenticacion).NotificarUsuarioSalir();

        //    _httpClient.DefaultRequestHeaders.Authorization = null;



        //}
    }
}
