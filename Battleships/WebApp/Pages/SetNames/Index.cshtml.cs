using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.SetNames
{
    public class Index : PageModel
    {
        private readonly DAL.AppDbContext _context;

        public Index(DAL.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)] public int GameId { get; set; }
        [BindProperty] public Game Game { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var game = await _context.Games
                .Where(x => x.GameId == GameId)
                .Include(x => x.GameOption)
                .ThenInclude(option => option!.GameOptionBoats)
                .Include(x => x.Player1)
                .Include(x => x.Player2)
                .FirstAsync();

            game.Description = Game.Description;
            game.Player1.Name = Game.Player1.Name;
            game.Player2.Name = Game.Player2.Name;
            await _context.SaveChangesAsync();

            //If no optionBoats were chosen redirect to WinPage and display player1 as winner.
            var total = 0;

            foreach (var optionBoat in game.GameOption!.GameOptionBoats)
            {
                total += optionBoat.Amount;
            }

            return Redirect(total == 0
                ? $"/BoardPage/Index?GameId={GameId}"
                : $"/PlaceBoatsPage/Index?GameId={GameId}&BoatsPlaced=0&P1Turn=true");
        }
    }
}