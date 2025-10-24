using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidrean_Iulia_Lab2.Models;

namespace Vidrean_Iulia_Lab2.Data
{
    public class Vidrean_Iulia_Lab2Context : DbContext
    {
        public Vidrean_Iulia_Lab2Context (DbContextOptions<Vidrean_Iulia_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Vidrean_Iulia_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Vidrean_Iulia_Lab2.Models.Publisher> Publisher { get; set; } = default!;

        public DbSet<Vidrean_Iulia_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Vidrean_Iulia_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
