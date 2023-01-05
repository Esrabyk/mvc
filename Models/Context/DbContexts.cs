using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YazilimTest.Models.Entities;

namespace YazilimTest.Models.Context
{
    public class DbContexts:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Lesson> Lessons { get; set; }


        public DbContexts(DbContextOptions<DbContexts> options) : base(options)
        {


        }
    }
}
