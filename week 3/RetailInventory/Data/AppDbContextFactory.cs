using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RetailInventory.Data;

public class AppDbContextFactory
  : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var builder = new DbContextOptionsBuilder<AppDbContext>();

        builder.UseSqlServer(
          @"Server=.\SQLEXPRESS;
            Database=RetailInventoryDb;
            Trusted_Connection=True;
            TrustServerCertificate=True"
        );


        return new AppDbContext(builder.Options);
    }
}
