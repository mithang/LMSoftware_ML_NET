using Microsoft.EntityFrameworkCore;
using SmartDiaryRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartDiaryRazor.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }
    }
}
