using Microsoft.EntityFrameworkCore;
using Sklep_z_grami.Data.Services;
using Sklep_z_grami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Data.Base
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _context;
        public GameService(AppDbContext context)
        {
            _context = context;
        }
        public async Task addAsync(Game game)
        {
            await _context.Games.AddAsync(game);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Games.FirstOrDefaultAsync(n => n.Id == id);
            _context.Games.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            var result = await _context.Games.Include(n => n.Publisher).Include(n => n.Shop).ToListAsync();
            return result;
        }

        public async Task<Game> GetByIdAsync(int id)
        {
            var result = await _context.Games.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<Game> UpdateAsync(int id, Game newGame)
        {
            _context.Update(newGame);
            await _context.SaveChangesAsync();
            return newGame;
        }

    }
}
