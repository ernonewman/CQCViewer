using System.Collections.Generic;
using CQCViewer.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace CQCViewer.Shared.DataContext
{
    public class SQLiteContext : DbContext
    {
        string _dbLocation;
        public SQLiteContext(string dbLocation = "cqc.db")
        {
            _dbLocation = dbLocation;
        }
        public DbSet<ProviderDetail> ProviderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={_dbLocation}");
    }
}
