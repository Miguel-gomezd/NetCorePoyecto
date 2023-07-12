using Microsoft.AspNetCore.Mvc;
using NetCorePoyecto.NewFolder;

namespace NetCorePoyecto.Controllers
   
{
    [ApiController]
    [Route("[cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public IActionResult listarCliente()
        {
            List<NewFolder.Cliente> clientes = new List<Cliente>
            {
                new Cliente
                {
                    id ="1",
                    correo = "google@gmail.com",
                    edad = "19",
                    nombre = "Bernardo Peña"
                },
                new Cliente
                {
                    id = "2",
                    correo = "miguelgoogle@gmail.com",
                    edad = "23",
                    nombre = "Miguel Mantilla"
                }
            };
            return clientes ;
        }

        [HttpGet]
        [Route("listarxid")]
        public IActionResult listarClientexid(int codigo )
        {
         
            return Ok( new Cliente
            {
                id = codigo.ToSting(),
                correo = "google@gmail.com",
                edad = "19",
                nombre = "Bernardo Peña"
            });
        }

        [HttpPost]
        [Route("eliminar")]
       public IActionResult eliminarCliente(Cliente cliente)
        {
         string token = Request.Headers.Where(x => x.Key =="Authorization").FirstOrDefault().value;

            if(token != "marco123.")
            {
                return Ok( new
                {
                    succes = false,
                    message = "token incorrecto",
                    result = ""
                });
            }
            return Ok( new
            {
                succes = true,
                message = "cliente eliminado",
                result = cliente
            });
        }
    }
}
