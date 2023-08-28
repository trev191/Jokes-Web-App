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
    public class IndexModel : PageModel
    {
        private readonly JokesWebApp.Data.ApplicationDbContext _context;

        public IndexModel(JokesWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Joke> Joke { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Joke != null)
            {
                Joke = await _context.Joke.ToListAsync();
            }
        }
    }
}
