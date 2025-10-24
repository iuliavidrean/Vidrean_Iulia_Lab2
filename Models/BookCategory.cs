namespace Vidrean_Iulia_Lab2.Models
{
    public class BookCategory
    {
        public int ID { get; set; } // cheia primara
        public int BookID { get; set; } // cheia FK la cheia primara a cartii participante
        public Book Book { get; set; } // accesul la detalii a cartii participante
        public int CategoryID { get; set; } // cheia FK la ID a categoriei
        public Category Category { get; set; } // accesul detaliilor a categoriei
    }
}
