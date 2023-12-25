using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore;

namespace ResistanceCalculator;
#nullable disable

public partial class ApplicationDBContext : DbContext
{

    public ApplicationDBContext()
    {

    }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

    }

    public virtual DbSet<Resistor> Resistors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CalculatorDB;Trusted_Connection=True;");
            optionsBuilder.UseMySQL("server=127.0.0.1;uid=root;database=CalculatorDB");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

