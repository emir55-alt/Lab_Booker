using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LabBooker.Infrastructure.Persistence;

public class LabBookerDbContextFactory : IDesignTimeDbContextFactory<LabBookerDbContext>
{
    public LabBookerDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LabBookerDbContext>();
        optionsBuilder.UseSqlite("Data Source=labbooker.db");

        return new LabBookerDbContext(optionsBuilder.Options);
    }
}