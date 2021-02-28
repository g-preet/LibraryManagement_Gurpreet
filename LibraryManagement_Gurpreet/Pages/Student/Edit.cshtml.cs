using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagement_Gurpreet.Biz;
using LibraryManagement_Gurpreet.Data;

namespace LibraryManagement_Gurpreet.Pages.Student
{
    public class EditModel : PageModel
    {
        private readonly LibraryManagement_Gurpreet.Data.ApplicationDbContext _context;

        public EditModel(LibraryManagement_Gurpreet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Biz.Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Students
                .Include(s => s.Author)
                .Include(s => s.Book).FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
           ViewData["AuthorID"] = new SelectList(_context.Authors, "ID", "Name");
           ViewData["BookID"] = new SelectList(_context.Books, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.ID))
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

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.ID == id);
        }
    }
}
