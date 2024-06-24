using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[]{
        new Evento()
        {
            EventoId = 1,
            Tema = ".NET CORE 6",
            Local = "São Paulo",
            Lote = "1 Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy")
        },
        new Evento()
        {
            EventoId = 2,
            Tema = "Angular 10",
            Local = "Belo Horizonte",
            Lote = "1 Lote",
            QtdPessoas = 350,
            DataEvento = DateTime.Now.AddDays(7).ToString("dd/MM/yyyy")
        }
    };

    public EventoController()
    {
       
    }

    [HttpGet]
    public IEnumerable<Evento> GetAll()
    {
        return _evento;
    }


    [HttpGet("{id}")]
    public IEnumerable<Evento> GetAll(int id)
    {
        return _evento.Where(x => x.EventoId == id);
    }
}
