
using Microsoft.EntityFrameworkCore;
using MyMicroservice.Domain.Entities;
using MyMicroservice.Infrastructure.Data;

namespace MyMicroservice.Infrastructure.Repositories;

public class TioRepository : ITioRepository
{
    private readonly AppDbContext _context;

    public TioRepository(AppDbContext context) => _context = context;

    public async Task<IEnumerable<Tio>> GetAllAsync() =>
        await _context.Tios.ToListAsync();

    public async Task<Tio?> GetByIdAsync(Guid id) =>
        await _context.Tios.FindAsync(id);

    public async Task CreateAsync(Tio tio)
    {
        if (tio.Id == Guid.Empty)
        {
            tio.Id = Guid.NewGuid(); // Asigna un nuevo GUID si el ID está vacío
        }

        _context.Tios.Add(tio);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tio tio)
    {
        _context.Tios.Update(tio);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var tio = await _context.Tios.FindAsync(id);
        if (tio != null)
        {
            _context.Tios.Remove(tio);
            await _context.SaveChangesAsync();
        }
    }
}