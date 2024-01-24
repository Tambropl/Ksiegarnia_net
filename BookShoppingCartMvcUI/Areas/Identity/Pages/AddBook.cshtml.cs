using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookShoppingCartMvcUI.Data;
using BookShoppingCartMvcUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookShoppingCartMvcUI.Pages.Admin
{
    public class AddBookModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AddBookModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; }

        public List<Genre> Genres { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Genres = await _context.Genres.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Genres = await _context.Genres.ToListAsync();
                return Page();
            }

            // Dodaj logikê zapisywania do bazy danych
            _context.Books.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Index");
        }
    }
}
