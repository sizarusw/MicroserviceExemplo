using Api.Produto.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Api.Produto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public List<Produto> Produtos { get; set; }

        private IProdutoRepository<Produto> _produto;

        public ProdutoController(IProdutoRepository<Produto> produto = null)
        {
            _produto = produto;

            RetornarProduto();

        }

        private void RetornarProduto()
        {

            List<Produto> listaProduto = new List<Produto>();

            listaProduto = _produto.GetAll();

            Produtos = listaProduto;

        }

        [HttpGet]
        public List<Produto> Get()
        {
            return Produtos;
        }

        [HttpGet("{id:int}")]
        public Produto Get(int id)
        {
            return Produtos.SingleOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async void Post()
        {

            string conteudoJSON = string.Empty;
            // Lendo os dados do Body
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                conteudoJSON = await reader.ReadToEndAsync();
            }

            Produto produto = JsonConvert.DeserializeObject<Produto>(conteudoJSON);

            _produto.Upsert(produto);

        }
    }
}
