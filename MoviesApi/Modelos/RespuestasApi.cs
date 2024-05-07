using System.Net;

namespace MoviesApi.Modelos
{
    public class RespuestasApi
    {
        public RespuestasApi()
        {
            Errors = new List<string>();
        }


        public HttpStatusCode StatusCode { get; set; }

        public bool IsSuccess { get; set; }

        public List<string> Errors { get; set; }

        public object Result { get; set; }
    }
}
