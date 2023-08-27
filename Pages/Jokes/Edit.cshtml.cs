using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Data;
using JokesWebApp.Models;

namespace JokesWebApp.Pages.Jokes
{
    public class EditModel : PageModel
    {
        private readonly JokesWebApp.Data.JokesWebAppContext _context;

        public EditModel(JokesWebApp.Data.JokesWebAppContext context)
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

            var joke =  await _context.Joke.FirstOrDefaultAsync(m => m.Id == id);
            if (joke == null)
            {
                return NotFound();
            }
            Joke = joke;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Joke).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JokeExists(Joke.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool JokeExists(int id)
        {
          return (_context.Joke?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
