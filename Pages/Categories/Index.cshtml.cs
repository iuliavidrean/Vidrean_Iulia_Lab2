using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Vidrean_Iulia_Lab2.Data;
using Vidrean_Iulia_Lab2.Models;

namespace Vidrean_Iulia_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Vidrean_Iulia_Lab2Context _context;

        public IndexModel(Vidrean_Iulia_Lab2Context context)
        {
            _context = context;
        }

        
        public CategoryData CategoryD { get; set; }

       
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id) 
        {
            CategoryD = new CategoryData();

            CategoryD.Categories = await _context.Category
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
               
                CategoryID = id.Value;

            
                var selectedCategory = await _context.Category
                    .Include(c => c.BookCategories)
                    .ThenInclude(bc => bc.Book)
                    .ThenInclude(b => b.Author) 
                    .AsNoTracking()
                    .FirstOrDefaultAsync(c => c.ID == id);

                if (selectedCategory != null)
                {
                  
                    CategoryD.Books = selectedCategory.BookCategories
                        .Select(bc => bc.Book);
                }
            }
        }
    }
}
