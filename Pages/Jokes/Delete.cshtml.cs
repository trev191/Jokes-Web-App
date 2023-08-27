using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Data;
using JokesWebApp.Models;

namespace JokesWebApp.Pages.Jokes
{
    public class DeleteModel : PageModel
    {
        private readonly JokesWebApp.Data.JokesWebAppContext _context;

        public DeleteModel(JokesWebApp.Data.JokesWebAppContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Joke Joke { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Joke == null)
            {
                return NotFound();
            }

            var joke = await _context.Joke.FirstOrDefaultAsync(m => m.Id == id);

            if (joke == null)
            {
                return NotFound();
            }
            else 
            {
                Joke = joke;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Joke == null)
            {
                return NotFound();
            }
            var joke = await _context.Joke.FindAsync(id);

            if (joke != null)
            {
                Joke = joke;
                _context.Joke.Remove(Joke);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
