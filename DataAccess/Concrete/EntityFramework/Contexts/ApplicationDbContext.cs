using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=ECommerceDb; Trusted_Connection=true");
        }

        public DbSet <Category> Categories { get; set; }
        public DbSet <Customer> Customers { get; set; }
        public DbSet <Order> Orders { get; set; }
        public DbSet <OrderDetail> OrderDetails { get; set; }
        public DbSet <Product> Products { get; set; }
        public DbSet <ProductImage> ProductImages { get; set; }
        public DbSet <OperationClaim> OperationClaims { get; set; }
        public DbSet <User> Users { get; set; }
        public DbSet <UserOperationClaim> UserOperationClaim { get; set; }


    }
}
