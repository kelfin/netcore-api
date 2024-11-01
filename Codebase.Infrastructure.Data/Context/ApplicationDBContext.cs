using System;
using Microsoft.EntityFrameworkCore;
using Codebase.Domain.Models;

namespace Codebase.Infrastructure.Data.Context;

public class ApplicationDBContext: DbContext
{
    public string DbPath { get; }
     public ApplicationDBContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "Codebase.db");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
}
