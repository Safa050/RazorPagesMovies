using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMovies.Data;
using RazorPagesMovies.Models;

namespace RazorPagesMovies.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovies.Data.RazorPagesMoviesContext _context;

        public IndexModel(RazorPagesMovies.Data.RazorPagesMoviesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        [BindProperty(SupportsGet=true)]
        public string SearchString { get; set; }
        public SelectList Genero { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenero { get; set; }
        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            if (!string.IsNullOrEmpty(MovieGenero))
            {
                movies = movies.Where(s => s.Genre.Contains(MovieGenero));
            }
            Genero = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
          //  Movie = await _context.Movie.ToListAsync();

        }
    }
}
