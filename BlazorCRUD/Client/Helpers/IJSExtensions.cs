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

        public static async Task<object> MostrarMensagem(this IJSRuntime js, string mensagem)
        {
            return await js.InvokeAsync<object>("Swal.fire", mensagem);
        }

        public static async Task<object> MostrarMensagem(this IJSRuntime js, string titulo, string mensagem, TipoMensagemSweetAlert tipoMensagemSweetAlert)
        {
            return await js.InvokeAsync<object>("Swal.fire", titulo, mensagem, tipoMensagemSweetAlert.ToString());
        }

        public static async Task<bool> Confirm(this IJSRuntime js, string titulo, string mensagem, TipoMensagemSweetAlert tipoMensagemSweetAlert)
        {
            return await js.InvokeAsync<bool>("customConfirm", titulo, mensagem, tipoMensagemSweetAlert.ToString());
        }
    }

    public enum TipoMensagemSweetAlert
    {
        question,
        warning,
        error,
        success,
        info
    }
}
