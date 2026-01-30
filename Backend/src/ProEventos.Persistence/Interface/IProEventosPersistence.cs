using ProEventos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Persistence.Interface
{
    public interface IProEventosPersistence
    {
        //GERAL
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        void DeleteRange<T>(T[] entity) where T: class;

        Task<bool> SaveChangesAsync();

        //Eventos
        Task<Evento[]> GetAllEventosAsync(bool includePalestrantes);
        Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes);
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes);

        //Palestrantes
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos);
    }
}
