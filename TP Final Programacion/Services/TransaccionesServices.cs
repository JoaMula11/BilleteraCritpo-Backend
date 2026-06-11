using TP_Final_Programacion.Models;
using TP_Final_Programacion.Interfaces;
using TP_Final_Programacion.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;


namespace TP_Final_Programacion.Services
{
    public class TransaccionesServices : ITransaccionesServices
    {
        private readonly AppDbContext _context;
        private readonly HttpClient _httpClient;
    
        public TransaccionesServices(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Transactions>> Get()
        {
            return await _context.Transactions
                .OrderByDescending(t => t.fecha)
                .ToListAsync();
        }

        public async Task<Transactions> Post(TransactionsDTO transactionsDTO)
        {
            string cryptoCodeLower = transactionsDTO.CodigoCriptomoneda.ToLower();

            string urlCriptoya = $"https://criptoya.com/api/fiwind/{cryptoCodeLower}/ars";

            decimal precio = 0;

            try
            {
                var response = await _httpClient.GetAsync(urlCriptoya);

                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(jsonString))
                    {
                        precio = doc.RootElement.GetProperty("totalAsk").GetDecimal();
                    }
                }
                else
                {
                    throw new Exception("No se pudo obtener el precio desde CryptoYa");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al consultar CryptoYa" + ex.Message);
            }

            decimal TotalGastado = precio * transactionsDTO.CryptoAmount;

            var transaction = new Transactions
            {
                codigoCriptomoneda = transactionsDTO.CodigoCriptomoneda,
                accion = transactionsDTO.Accion,
                ClienteId = transactionsDTO.ClienteId,
                CryptoAmount = transactionsDTO.CryptoAmount,
                Moneda = TotalGastado,
                fecha = DateTime.UtcNow
            };
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
            return transaction;

        }

    }
}
