using ProEventos.Domain.Models;

namespace ProEventos.Persistence.Interface
{
    public interface IPalestrantePersistence
    {
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
    }
}
