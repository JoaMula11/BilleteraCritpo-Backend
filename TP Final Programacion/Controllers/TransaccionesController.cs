using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TP_Final_Programacion.Interfaces;
using TP_Final_Programacion.DTOs;
using TP_Final_Programacion.Models;

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
        public async Task<ActionResult<IEnumerable<Transactions>>> Get()
        {
            var transactions = await _transaccionesServices.Get();
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Transactions>> GetById(int id)
        {
            var transaction = await _transaccionesServices.GetByid(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<ActionResult> Post(TransactionsDTO transactionsDTO)
        {
            if (transactionsDTO == null)
            {
                return BadRequest();
            }
            var transaction = await _transaccionesServices.Post(transactionsDTO);
            return Ok(transaction);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TransactionsDTO transactionsDTO)
        {
            if (transactionsDTO == null || id != transactionsDTO.Id)
            {
                return BadRequest();
            }

      
            bool modificado = await _transaccionesServices.Put(id, transactionsDTO);

            if (!modificado)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var transaction = await _transaccionesServices.GetByid(id);
            if (transaction == null)
            {
                return NotFound();
            }

            try
            {
                bool eliminado = await _transaccionesServices.Delete(id);
                if (!eliminado)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { mensaje = "No se pudo eliminar la transacción. Verifique si está vinculada a otros datos.", detalle = ex.Message });
            }
        }
    }
}