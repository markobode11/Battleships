using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly DAL.AppDbContext _context;
        
        public IndexModel(AppDbContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            if (!_context.Boats.Any())
            {
                var names = new List<string>()
                {
                    "Patrol",
                    "Submarine",
                    "Battleship",
                    "Destroyer",
                    "Cruiser"
                };
                for (int i = 0; i < 5; i++)
                {
                    _context.Boats.Add(new Boat
                    {
                        Name = names[i],
                        Size = i + 1
                    });
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}