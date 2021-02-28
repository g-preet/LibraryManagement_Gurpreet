using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibraryManagement_Gurpreet.Biz;
using LibraryManagement_Gurpreet.Data;

namespace LibraryManagement_Gurpreet.Pages.Student
{
    public class CreateModel : PageModel
    {
        private readonly LibraryManagement_Gurpreet.Data.ApplicationDbContext _context;

        public CreateModel(LibraryManagement_Gurpreet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "Name");
        ViewData["BookID"] = new SelectList(_context.Books, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Biz.Student Student { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
