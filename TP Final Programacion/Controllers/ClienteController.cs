using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Final_Programacion.DTOs;
using TP_Final_Programacion.Services;

namespace TP_Final_Programacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteDTO>>> Get(ClienteService clienteService)
        {
            var transactions = await clienteService.Get();
            return Ok(transactions);
        }
    }
}
