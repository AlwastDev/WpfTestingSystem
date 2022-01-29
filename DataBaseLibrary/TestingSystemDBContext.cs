using DataBaseLibrary.Models;
using Microsoft.EntityFrameworkCore;
namespace DataBaseLibrary
{
    public sealed class TestingSystemDbContext : DbContext
    {
        public TestingSystemDbContext(DbContextOptions<TestingSystemDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-FP7F3LT\MSSQLSERVER_ALEX;initial catalog=TestingSystemDB;Trusted_Connection=True;MultipleActiveResultSets=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasMany(t => t.Questions).WithMany(t => t.Answers);
            modelBuilder.Entity<Test>().HasMany(p => p.Questions).WithOne(p => p.Test).HasForeignKey(s => s.TestId).OnDelete(DeleteBehavior.SetNull);
            base.OnModelCreating(modelBuilder);
        }
    } 
}