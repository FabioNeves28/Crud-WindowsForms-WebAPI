using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp10
{
    public class UnidadeMedida
    {
 
        public string Sigla { get; set; } = null!;
        public string? Descricao { get; set; }
        public bool? CasasDecimais { get; set; }
        public string? Ativa { get; set; }
        public int? CadastradoUsuario { get; set; }
        public DateTime? CadastradoData { get; set; }
        public int? AlteradoUsuario { get; set; }
        public DateTime? AlteradoData { get; set; }

        public async Task<List<UnidadeMedida>> ObterUnidadeMedidaAsyncAll()
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:7288/api/UnidadesMedidas", Method.GET);

            var response = await client.ExecuteAsync<List<UnidadeMedida>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Data;
            else
                return null;
        }

      
    }
}

