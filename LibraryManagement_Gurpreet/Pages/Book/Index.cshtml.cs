﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly LibraryManagement_Gurpreet.Data.ApplicationDbContext _context;

        public IndexModel(LibraryManagement_Gurpreet.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Biz.Book> Book { get;set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Books.ToListAsync();
        }
    }
}
