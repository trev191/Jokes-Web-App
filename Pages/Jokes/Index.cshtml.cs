using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JokesWebApp.Data;
using JokesWebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JokesWebApp.Pages.Jokes
{
    public class IndexModel : PageModel
    {
        private readonly JokesWebApp.Data.ApplicationDbContext _context;

        public IndexModel(JokesWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Joke> Joke { get;set; } = default!;

        // For allowing search functionality
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Jokes { get; set; }
        public async Task OnGetAsync()
        {
            var jokes = from j in _context.Joke
                        select j;
            if (!string.IsNullOrEmpty(SearchString))
            {
                jokes = jokes.Where(s => s.JokeQuestion.Contains(SearchString));
            }

            Joke = await jokes.ToListAsync();
        }
    }
}
