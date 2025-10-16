﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Vidrean_Iulia_Lab2.Models
{
    public class Book
    {
        public int ID { get; set; }
        [Display(Name = "Book Title")]
        public string Title { get; set; }
        public int? AuthorID { get; set; } // Cheia străină (Foreign Key)
        public Author? Author { get; set; }
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }



        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }
    }
}
