﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibraryManagement_Gurpreet.Biz;
using LibraryManagement_Gurpreet.Data;

namespace LibraryManagement_Gurpreet.Pages.Student
{
    public class IndexModel : PageModel
    {
        private readonly LibraryManagement_Gurpreet.Data.ApplicationDbContext _context;

        public IndexModel(LibraryManagement_Gurpreet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Biz.Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Students
                .Include(s => s.Author)
                .Include(s => s.Book).ToListAsync();
        }
    }
}
