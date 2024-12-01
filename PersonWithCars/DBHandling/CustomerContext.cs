using Microsoft.EntityFrameworkCore;

namespace PersonWithCars.DBHandling;

public partial class CustomerContext : DbContext
{
    public CustomerContext(DbContextOptions<CustomerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<Person> Persons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Cars__3214EC0703A959F4");

            entity.Property(e => e.CardBrand).HasMaxLength(200);
            entity.Property(e => e.LicensePlate).HasMaxLength(8);

            entity.HasOne(d => d.Person).WithMany(p => p.Cars)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK__Cars__PersonId__3E52440B");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Persons__3214EC072A9F4294");

            entity.Property(e => e.BirthDay).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.PAddress).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
