using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Criste_Rares_Lab2.Models;

namespace Criste_Rares_Lab2.Data
{
    public class Criste_Rares_Lab2Context : DbContext
    {
        public Criste_Rares_Lab2Context (DbContextOptions<Criste_Rares_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Criste_Rares_Lab2.Models.Book> Book { get; set; } = default!;

        public DbSet<Criste_Rares_Lab2.Models.Publisher>? Publisher { get; set; }

        public DbSet<Criste_Rares_Lab2.Models.Author>? Authors { get; set; }
    }
}
