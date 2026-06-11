using TP_Final_Programacion.Models;
using TP_Final_Programacion.Interfaces;
using TP_Final_Programacion.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;


namespace TP_Final_Programacion.Services
{

    public class ClienteService
    {
        private readonly AppDbContext _context;
        public ClienteService(AppDbContext context, HttpClient httpClient)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transactions>> Get()
        {
            return await _context.Transactions
                .OrderByDescending(t => t.fecha)
                .ToListAsync();
        }

    }
}
    
    
