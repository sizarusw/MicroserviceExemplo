using Api.Cliente.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Api.Cliente
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public List<Cliente> Clientes { get; set; }

        private IClienteRepository<Cliente> _cliente;

        public ClienteController(IClienteRepository<Cliente> cliente = null)
        {
            _cliente = cliente;

            RetornarCliente();

        }

        private void RetornarCliente()
        {

            List<Cliente> listaCliente = new List<Cliente>();

            listaCliente = _cliente.GetAll();

            Clientes = listaCliente;

        }

        [HttpGet]
        public List<Cliente> Get()
        {
            return Clientes;
        }

        [HttpGet("{id:int}")]
        public Cliente Get(int id)
        {
            return Clientes.SingleOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async void Post()
        {
            string conteudoJSON = "";
            // Lendo os dados do Body
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                conteudoJSON = await reader.ReadToEndAsync();
            }

            Cliente cliente = JsonConvert.DeserializeObject<Cliente>(conteudoJSON);

            _cliente.Upsert(cliente);
        }

    }
}
