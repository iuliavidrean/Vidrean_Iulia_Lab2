namespace Vidrean_Iulia_Lab2.Models
{
    public class Category
    {
        public int ID { get; set; } // cheia primara
        public string CategoryName { get; set; } // categoria
        public ICollection<BookCategory>? BookCategories { get; set; } // o categorie poate fi asociata cu mai multe inregistrari bookcategory
    }
}
