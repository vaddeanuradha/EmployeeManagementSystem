using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem;
namespace EmployeeManagementSystemDbContext
{
    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> DbEmployees { get; set; }
        public DbSet<Transaction> DbTransactions { get; set; }
       

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeManagementSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                .HasName("PK_DbEmployees");

                entity.Property(e => e.EmpId)
                      .ValueGeneratedOnAdd();

                entity.Property(e => e.Email)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.EmpName)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.EManagerId)
                      .IsRequired()
                      .HasMaxLength(50);

                entity.Property(e => e.Address)
                      .IsRequired()
                      .HasMaxLength(50);


                entity.Property(e => e.Contact)
                      .IsRequired()
                      .HasMaxLength(50);





            });
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                .HasName("PK_DbTransactions");

                entity.Property(e => e.TransactionId)
                      .ValueGeneratedOnAdd();


            });

           
           
        }
    }
}