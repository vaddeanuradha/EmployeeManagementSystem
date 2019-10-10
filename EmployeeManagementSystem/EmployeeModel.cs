using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem
{
    public class EmployeeModel : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
       

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
                .HasName("PK_Employees");

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
                .HasName("PK_Transactions");

                entity.Property(e => e.TransactionId)
                      .ValueGeneratedOnAdd();


            });
             
           
        }
    }
}

