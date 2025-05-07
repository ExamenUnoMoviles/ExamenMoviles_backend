using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamenMoviles_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenMoviles_backend.Data
{
  public class ApplicationDBContext : DbContext
  {
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

    public DbSet<Course> Courses { get; set; }
    public DbSet<Student> Student { get; set; }
  }
}