using Criste_Rares_Lab2.Models;
namespace Criste_Rares_Lab2.Models.ViewModels
{
    public class CategoriesIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }

    }
}
