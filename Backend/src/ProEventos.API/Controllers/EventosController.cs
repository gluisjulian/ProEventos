using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Interface;
using ProEventos.Domain.Models;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    private readonly IEventoService _eventoService;
    
    public EventosController(IEventoService eventoService)
    {
        _eventoService = eventoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEventos()
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosAsync(true);
            if (eventos == null) return NotFound("Nenhum evento encontrado!");

            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar os eventos: Erro: {ex.Message}");
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEventoById(int id)
    {
        try
        {
            var evento = await _eventoService.GetEventoByIdAsync(id, true);
            if (evento == null) return NotFound("Nenhum evento encontrado!");

            return Ok(evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar os eventos: Erro: {ex.Message}");
        }
    }

    [HttpGet("tema/{tema}")]
    public async Task<IActionResult> GetEventoByTema(string tema)
    {
        try
        {
            var eventos = await _eventoService.GetAllEventosByTemaAsync(tema, true);
            if (eventos == null) return NotFound("Eventos por tema nao encontrados!");

            return Ok(eventos);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar retornar os eventos: Erro: {ex.Message}");
        }
    }

    [HttpPost]
    public async Task<IActionResult> PostEvento(Evento model)
    {
        try
        {
            var evento = await _eventoService.AddEvento(model);
            if (evento == null) return BadRequest("Erro ao tentar adicionar evento.");

            return Ok(evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar adicionar um evento. Erro: {ex.Message}");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEvento(int id, Evento model)
    {
        try
        {
            var evento = await _eventoService.UpdateEvento(id, model);
            if (evento == null) return BadRequest("Erro ao tentar atualizar um evento.");

            return Ok(evento);
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar atualizar um evento. Erro: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEvento(int id)
    {
        try
        {
            if(await _eventoService.DeleteEvento(id))
                return Ok("Evento deletado");
            else
                return BadRequest("Evento não deletado");
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar deletar um evento. Erro: {ex.Message}");
        }
    }
}
