using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Final_Programacion.Interfaces;
using TP_Final_Programacion.DTOs;

namespace TP_Final_Programacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransaccionesController : ControllerBase
    {
        private readonly ITransaccionesServices _transaccionesServices;

        public TransaccionesController(ITransaccionesServices transaccionesServices)
        {
            _transaccionesServices = transaccionesServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionsDTO>>> Get()
        {
            var transactions = await _transaccionesServices.Get();
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<ActionResult<TransactionsDTO>> Post(TransactionsDTO transactionsDTO)
        {
            if (transactionsDTO == null)
            {
                return BadRequest();
            }
            var transaction = await _transaccionesServices.Post(transactionsDTO);
            return Ok(transaction);
        }
    }
}
