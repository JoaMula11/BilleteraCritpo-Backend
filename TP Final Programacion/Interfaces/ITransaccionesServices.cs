using TP_Final_Programacion.DTOs;
using TP_Final_Programacion.Models;

namespace TP_Final_Programacion.Interfaces
{
    public interface ITransaccionesServices
    {
        Task<IEnumerable<Transactions>> Get();
        Task<Transactions> Post(TransactionsDTO transactions);

    }
}
