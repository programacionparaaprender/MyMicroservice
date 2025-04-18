
using Microsoft.AspNetCore.Mvc;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MyMicroservice.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TioController : ControllerBase
{
    private readonly ITioRepository _tioRepository;

    public TioController(ITioRepository tioRepository)
    {
        _tioRepository = tioRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tios = await _tioRepository.GetAllAsync();
        return Ok(tios);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var tio = await _tioRepository.GetByIdAsync(id);
        if (tio == null) return NotFound();
        return Ok(tio);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Tio tio)
    {
        await _tioRepository.CreateAsync(tio);
        return CreatedAtAction(nameof(GetById), new { id = tio.Id }, tio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Tio tio)
    {
        var exists = await _tioRepository.GetByIdAsync(id);
        if (exists == null) return NotFound();

        tio.Id = id;
        await _tioRepository.UpdateAsync(tio);
        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var exists = await _tioRepository.GetByIdAsync(id);
        if (exists == null) return NotFound();

        await _tioRepository.DeleteAsync(id);
        return NoContent();
    }
}