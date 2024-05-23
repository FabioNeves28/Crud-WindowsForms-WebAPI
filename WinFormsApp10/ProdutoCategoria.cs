using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp10
{
    public class ProdutoCategoria
    {

        public int Id { get; set; }
        public string? Descricao { get; set; }
        public string? Ativa { get; set; }
        public int? CadastradoUsuario { get; set; }
        public DateTime? CadastradoData { get; set; }
        public int? AlteradoUsuario { get; set; }
        public DateTime? AlteradoData { get; set; }


        public async Task<List<ProdutoCategoria>> ObterProdutoCategoriaAsyncAll()
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:7288/api/ProdutosCategorias", Method.GET);

            var response = await client.ExecuteAsync<List<ProdutoCategoria>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Data;
            else
                return null;
        }
    
}
}
