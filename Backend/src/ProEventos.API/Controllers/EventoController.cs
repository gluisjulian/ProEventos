using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[]
    {
        new Evento()
        {
            EventoId = 1,
            Tema = "Angular 11 e .NET CORE 5",
            Local = "Belo Horizonte",
            Lote = "1º Lote",
            QtdPessoas = 250,
            DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy"),
            ImagemURL = "foto.png"
        },
        new Evento()
        {
             EventoId = 2,
             Tema = "Angular 11 e .NET CORE 6",
             Local = "São Paulo",
             Lote = "1º Lote",
             QtdPessoas = 300,
             DataEvento = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy"),
             ImagemURL = "fotoSP.png"
        }
    };


    public EventoController()
    {
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento;
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _evento.Where(e => e.EventoId == id);
    }
}
