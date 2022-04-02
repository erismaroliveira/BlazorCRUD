using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorCRUD.Client.Helpers
{
    public static class IJSExtensions
    {
        public static async Task<object> SalvarComo(this IJSRuntime js, string nomeArquivo, byte[] arquivo)
        {
            return await js.InvokeAsync<object>("saveAsFile", 
                nomeArquivo, 
                Convert.ToBase64String(arquivo));
        }
    }
}
