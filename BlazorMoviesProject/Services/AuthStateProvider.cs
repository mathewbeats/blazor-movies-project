using Blazored.LocalStorage;
using BlazorMoviesProject.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Security.Claims;


namespace BlazorMoviesProject.Services
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _httpClient;

        private readonly ILocalStorageService _localStorageService;

       

        public AuthStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;

            _localStorageService = localStorageService;

           
        }

        //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        //{
        //    var token = await _localStorageService.GetItemAsync<string>(Inicializar.Token_Local);

        //    if (token == null)
        //    {
        //        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

        //    }
        //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

        //    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        //}


        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorageService.GetItemAsync<string>(Inicializar.Token_Local);
            if (token == null)
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        }


        public void NotificarUsuarioLogueado(string token)
        {
            var autenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(autenticatedUser));
            NotifyAuthenticationStateChanged(authState);
        }

        //public void NotificarUsuarioSalir()
        //{
        //    var authState = Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));
        //    NotifyAuthenticationStateChanged(authState);
        //}


        public void NotificarUsuarioSalir()
        {
            var anonimo = new ClaimsPrincipal(new ClaimsIdentity()); // Crea un principal anónimo
            var authState = Task.FromResult(new AuthenticationState(anonimo));
            NotifyAuthenticationStateChanged(authState); // Notifica el cambio de estado
            Console.WriteLine("Notificación de estado de autenticación enviada.");


        }


        

    }
}
