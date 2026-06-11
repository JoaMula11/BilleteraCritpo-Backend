using TP_Final_Programacion.DTOs;
using TP_Final_Programacion.Models;

namespace TP_Final_Programacion.Interfaces
{
    public interface ITransaccionesServices
    {
        Task<IEnumerable<Transactions>> Get();
        Task<Transactions> Post(TransactionsDTO transactions);
        Task<Transactions?> GetByid(int id);
        Task<bool> Put(int id, TransactionsDTO transactions);
        Task<bool> Delete(int id);

    }
}
