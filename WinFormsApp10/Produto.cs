using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace WinFormsApp10
{

    public class Produto
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public string un { get; set; }
        public int idCategoria { get; set; }
        public int precoCusto { get; set; }
        public int precoVenda { get; set; }
        public int estoqueMinimo { get; set; }
        public int estoqueMaximo { get; set; }
        public int estoqueSaldoInicial { get; set; }
        public object estoqueSaldoInicialData { get; set; }
        public string ativo { get; set; }
        public int cadastradoUsuario { get; set; }
        public DateTime cadastradoData { get; set; }
        public int alteradoUsuario { get; set; }
        public object alteradoData { get; set; }

        public async Task<List<Produto>> ObterProdutosAsyncAll()
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:7288/api/Produtos", Method.GET);

            var response = await client.ExecuteAsync<List<Produto>>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Data;
            else
                return null;
        }

        public async Task<Produto> ObterProdutoAsync(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:7288/api/Produtos/" + id, Method.GET);

            var response = await client.ExecuteAsync<Produto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Data;
            else
                return null;

        }
        public async Task<Produto> AlterarProdutoAsync(int id)
        {

            var client = new RestClient();
            var request = new RestRequest("https://localhost:7288/api/Produtos" + id, Method.PUT);

            var response = await client.ExecuteAsync<Produto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Data;
            else
                return null;
        }
        public async Task<Produto> AdicionarProdutoAsync()
        {

            var client = new RestClient();
            var request = new RestRequest("https://localhost:7288/api/Produtos", Method.POST);

            var response = await client.ExecuteAsync<Produto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Data;
            else
                return null;
        }
        public async Task<Produto> DeletarProdutoAsync(int id)
        {
            var client = new RestClient();
            var request = new RestRequest("https://localhost:7288/api/Produtos" + id, Method.DELETE);

            var response = await client.ExecuteAsync<Produto>(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Data;
            else
                return null;
        }

    }

}
