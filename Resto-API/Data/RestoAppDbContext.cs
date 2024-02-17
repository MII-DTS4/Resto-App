﻿using Microsoft.EntityFrameworkCore;
using Resto_API.Models;

namespace Resto_API.Data
{
    public class RestoAppDbContext : DbContext
    {

        public RestoAppDbContext(DbContextOptions<RestoAppDbContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountRole> AccountRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasIndex(r => r.RoleName).IsUnique();

            modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountRoles)
                .WithOne(ar => ar.Account)
                .HasForeignKey(ar => ar.AccountGuid);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.AccountRoles)
                .WithOne(ar => ar.Role)
                .HasForeignKey(ar => ar.RoleGuid);

            modelBuilder.Entity<Customer>()
               .HasOne(c => c.Account)
               .WithOne(a => a.Customer)
               .HasForeignKey<Account>(a => a.Guid);

            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Transactions)
                .WithOne(t => t.Customer)
                .HasForeignKey(t => t.CustomerGuid);

            modelBuilder.Entity<Transaction>()
                .HasMany(t => t.Orders)
                .WithOne(o => o.Transaction)
                .HasForeignKey(o => o.CustomerGuid);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Orders)
                .WithOne(o => o.Item)
                .HasForeignKey(o => o.ItemGuid);

            modelBuilder.Entity<Role>().HasData(
                new Role { Guid = Guid.NewGuid(), RoleName = "Customer", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now },
                new Role { Guid = Guid.NewGuid(), RoleName = "Admin", CreatedDate = DateTime.Now, ModifiedDate = DateTime.Now }
                );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Guid = Guid.NewGuid(),
                    FirstName = "Ann",
                    LastName = "Tony",
                    PhoneNumber = "082234435555",
                    Address = "another world",
                    Email = "ann.tony@email.com",
                    Gender = 0,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now
                }
                );
        }
    }
}
