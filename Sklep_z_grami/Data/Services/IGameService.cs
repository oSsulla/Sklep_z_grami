using Sklep_z_grami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Data.Services
{
    public interface IGameService
    {
        Task<IEnumerable<Game>> GetAllAsync();
        Task<Game> GetByIdAsync(int id);
        Task addAsync(Game game);
        Task<Game> UpdateAsync(int id, Game newGame);
        Task DeleteAsync(int id);
    }
}
