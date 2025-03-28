using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoginAuth.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginAuth.DAL.AppDbContext 
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Users> Users { get; set; }
    }
}
