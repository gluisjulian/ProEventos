using ProEventos.Application.Interface;
using ProEventos.Domain.Models;
using ProEventos.Persistence.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProEventos.Application.Implementation
{
    public class EventoService : IEventoService
    {
        private readonly IEventoPersistence _eventosPersistence;
        private readonly IGeralPersistence _geralPersistence;

        public EventoService(IGeralPersistence geralPersistence, IEventoPersistence eventosPersistence)
        {
            _eventosPersistence = eventosPersistence;
            _geralPersistence = geralPersistence;
        }

        public async Task<Evento> AddEvento(Evento evento)
        {
            try
            {
                _geralPersistence.Add(evento);
                if(await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventosPersistence.GetEventoByIdAsync(evento.Id, false);
                }
                return null;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await _eventosPersistence.GetEventoByIdAsync(eventoId, false);
                model.Id = evento.Id;

                if (evento == null)
                    return null;

                _geralPersistence.Update(evento);
                if (await _geralPersistence.SaveChangesAsync())
                {
                    return await _eventosPersistence.GetEventoByIdAsync(evento.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await _eventosPersistence.GetEventoByIdAsync(eventoId, false);

                if (evento == null)
                    throw new Exception("Evento para delete não foi encontrado.");

                _geralPersistence.Delete(evento);
                return await _geralPersistence.SaveChangesAsync();

    
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento[]> GetAllEventosAsync(bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventosPersistence.GetAllEventosAsync(includePalestrantes);
                if (eventos == null)
                    return null;

                return eventos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Evento> GetEventoByIdAsync(int eventoId, bool includePalestrantes = false)
        {
            try
            {
                var evento = await _eventosPersistence.GetEventoByIdAsync(eventoId, includePalestrantes);
                if (evento == null)
                    return null;

                return evento;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false)
        {
            try
            {
                var eventos = await _eventosPersistence.GetAllEventosByTemaAsync(tema, includePalestrantes);
                if (eventos == null)
                    return null;

                return eventos;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
