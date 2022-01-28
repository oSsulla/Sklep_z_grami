using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sklep_z_grami.Data.Services;
using Sklep_z_grami.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sklep_z_grami.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGameController : ControllerBase
    {
        [Route("api/books")]
        [ApiController]
        public class ApiBookController : ControllerBase
        {
            private IGameService games;

            public ApiBookController(IGameService games)
            {
                this.games = games;
            }

            //deklaracja zmiennej repozytorium
            [HttpGet]

            public Task<IEnumerable<Game>>  GetGames()
            {
                return games.GetAllAsync();
            }

           


            [HttpGet("{id}")]

            public async Task<ActionResult<Game>> GetGame(int id)
            {
                Game game =await games.GetByIdAsync(id);
                if (game != null)
                {
                    return new OkObjectResult(game);
                }
                else
                {
                    return new NotFoundResult();
                }
            }

            [HttpPut("{id}")]
            public ActionResult<Game> EditGame(int id, [FromBody] Game game)
            {
                //wywołanie metody z repozytorium zmieniającej wartości w obiekcie
                //testujemy, czy obiekt jest różny od null
                if (id < 5 && id > 0)
                {
                    game.Id = id;
                    return new OkObjectResult(game);
                }
                else
                {
                    return NotFound();
                }
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteGame(int id)
            {
                //usunięcie z repozytorium obiektu o podanym id
                //jeśli nie ma obiektu do usunięcia to zwracamy NotFound
                if (id < 5 && id > 0)
                {
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
}
