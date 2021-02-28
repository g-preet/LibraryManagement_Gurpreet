using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryManagement_Gurpreet.Biz;
using LibraryManagement_Gurpreet.Data;

namespace LibraryManagement_Gurpreet.Pages.Book
{
    public class DetailsModel : PageModel
    {
        private readonly LibraryManagement_Gurpreet.Data.ApplicationDbContext _context;

        public DetailsModel(LibraryManagement_Gurpreet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Biz.Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Books.FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
