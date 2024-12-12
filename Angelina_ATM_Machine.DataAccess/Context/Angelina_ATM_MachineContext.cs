using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Angelina_ATM_Machine.DataAccess.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CRUDApps.DataAccess.EF.Context
{
    public partial class Angelina_ATM_MachineContext : DbContext
    {        

        public Angelina_ATM_MachineContext()
        {
            
        }

        public Angelina_ATM_MachineContext(DbContextOptions<Angelina_ATM_MachineContext> options)
            : base(options)
        {
            
        }


        public virtual DbSet<ClientModel> Client { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientModel>(entity =>
            {
                entity.HasKey(e => e.ClientId);

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

               // entity.Property(e => e.ClientAccountBalance).HasColumnType("decimal(14, 2)");

                entity.Property(e => e.AccountNumber)
                    .IsRequired();

                entity.Property(e => e.AccountHolder)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(e => e.Balance)
                    .IsRequired();
            });

            
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
