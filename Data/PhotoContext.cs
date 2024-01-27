using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.EntityFrameworkCore;
using TH.Models;

namespace TH.Data;

//dotnet ef dbcontext scaffold "Data Source=DESKTOP-CURC7TC\\LEHUY;Initial Catalog=Photo;User Id=sa;Password=123;Trusted_Connection=False;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -f

public partial class PhotoContext : DbContext
{
    public PhotoContext()
    {
    }

    public PhotoContext(DbContextOptions<PhotoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Debt> Debt { get; set; }

    public virtual DbSet<Users> Users { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-CURC7TC\\LEHUY;Initial Catalog=Photo;User Id=sa;Password=123;Trusted_Connection=False;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Debt>(entity =>
        {
            entity.HasKey(e => e.DebtID).HasName("PK__Debt__5F7687B5039AC7FB");

            entity.ToTable("Debt");

            entity.Property(e => e.DebtID).HasColumnName("DebtID");
            entity.Property(e => e.DebtAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DueDate).HasColumnType("date");
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserID).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Debts)
                .HasForeignKey(d => d.UserID)
                .HasConstraintName("FK__Debt__UserID__619B8048");
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
