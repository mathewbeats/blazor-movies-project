using Microsoft.JSInterop;

namespace BlazorMoviesProject.Helpers
{

    //esta clase va a ser estatica porque tenemos que llamarla desde los components
    //para habilitar los toaster con js
    public static class IJsHelper
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }

        public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message);
        }


        public static async ValueTask CarrouselBlazor(this IJSRuntime jSRuntime)
        {
            await jSRuntime.CarrouselBlazor();
        }
    }
}
