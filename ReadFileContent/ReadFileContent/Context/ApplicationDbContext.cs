using Microsoft.EntityFrameworkCore;
using ReadFileContent.Models;
using ReadFileContent.Controllers;

namespace ReadFileContent.Context
{
    public class ApplicationDbContext : DbContext
    {
      
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FileContents> FileContents
        {
            get;
            set;
        }


    }
}
