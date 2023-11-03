using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Criste_Rares_Lab2.Data;
using Criste_Rares_Lab2.Models;
using Criste_Rares_Lab2.Models.ViewModels;
using System.Security.Policy;

namespace Criste_Rares_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Criste_Rares_Lab2.Data.Criste_Rares_Lab2Context _context;

        public IndexModel(Criste_Rares_Lab2.Data.Criste_Rares_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;
        public CategoriesIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoriesIndexData();
            CategoryData.Categories = await _context.Category
            .Include(i => i.BookCategories)
            .ThenInclude(c => c.Book.Author)
            .OrderBy(i => i.CategoryName)
            .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(c => c.Book);
            }
        }
    }
}
