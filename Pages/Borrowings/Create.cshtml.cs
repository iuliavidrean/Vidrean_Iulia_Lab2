using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vidrean_Iulia_Lab2.Data;
using Vidrean_Iulia_Lab2.Models;

namespace Vidrean_Iulia_Lab2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Vidrean_Iulia_Lab2.Data.Vidrean_Iulia_Lab2Context _context;

        public CreateModel(Vidrean_Iulia_Lab2.Data.Vidrean_Iulia_Lab2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
                .Include(b => b.Author) 
                .Select(x => new
                {
                    x.ID,
                    BookFullName = x.Title + " - " + x.Author!.LastName + " " + x.Author.FirstName 
                });

            
            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
            // ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");

            var memberList = _context.Member
                .OrderBy(m => m.LastName) 
                .Select(x => new
                {
                    x.ID,
                    FullName = x.FirstName + " " + x.LastName
                }); 

            ViewData["MemberID"] = new SelectList(memberList, "ID", "FullName");

            return Page();
        }



        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
