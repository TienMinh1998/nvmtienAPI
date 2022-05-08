
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIProject.Domain.Models;

namespace APIProject.Domain
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Student> students { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuation Person Table  :
            var persons = modelBuilder.HasDefaultSchema("Minhtien").Entity<Person>();
            persons.HasKey(x => x.Id);
            persons.Property(x => x.Age).IsRequired();
            modelBuilder.HasDefaultSchema("minhtien2").Entity<User>();

            var studentTable = modelBuilder.Entity<Student>();
            studentTable.HasKey(x => x.StudentId);
            studentTable.ToTable("Students");
            studentTable.Property(x => x.Name).IsRequired();


            // Configuation category table and User table
            modelBuilder.Entity<Category>().HasOne(c => c.User)
                .WithMany(u => u.categories)
                .HasForeignKey(s => s.UserId);
            
            // Configuation for Question table
            modelBuilder.Entity<Question>().HasOne(q => q.User).WithMany(u => u.Questions).HasForeignKey(q => q.UserId);
        }
    }
}