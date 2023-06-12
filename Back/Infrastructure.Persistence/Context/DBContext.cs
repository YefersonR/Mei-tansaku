using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Context
{
    public class DBContext : DbContext
    {
        public DbSet<Attribute_Category> Attribute_Category { get; set; }
        public DbSet<Category> Category{ get; set; }
        public DbSet<Chat> Chat{ get; set; }
        public DbSet<Comment> Comment{ get; set; }
        public DbSet<Helpful> Helpful{ get; set; }
        public DbSet<Messages> Message { get; set; }
        public DbSet<Product> Product{ get; set; }
        public DbSet<Product_Application> Product_Application{ get; set; }
        public DbSet<Product_List> Product_List{ get; set; }
        public DbSet<Product_Rating> Product_Rating{ get; set; }
        public DbSet<Purchased> Purchased{ get; set; }
        public DbSet<Reason> Reason{ get; set; }
        public DbSet<Reports> Reports{ get; set; }
        public DbSet<Seller_Application> Seller_Application{ get; set; }
        public DbSet<Seller_Rating> Seller_Rating{ get; set; }
        public DbSet<State> States{ get; set; }
        public DbSet<Tickets> Tickets{ get; set; }
        public DbSet<Value_Attribute> Value_Attribute{ get; set; }
        public DBContext(DbContextOptions options):base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Tables
           
            modelBuilder.Entity<Attribute_Category>().ToTable("Attribute_category");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Chat>().ToTable("Chat");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Helpful>().ToTable("Helpful");
            modelBuilder.Entity<Messages>().ToTable("Messages");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product_Application>().ToTable("Product_Application");
            modelBuilder.Entity<Product_List>().ToTable("Product_list");
            modelBuilder.Entity<Product_Rating>().ToTable("Product_rating");
            modelBuilder.Entity<Purchased>().ToTable("Purchased");
            modelBuilder.Entity<Reason>().ToTable("Reason");
            modelBuilder.Entity<Reports>().ToTable("Reports");
            modelBuilder.Entity<Seller_Application>().ToTable("Seller_Application");
            modelBuilder.Entity<Seller_Rating>().ToTable("Seller_Rating");
            modelBuilder.Entity<State>().ToTable("State");
            modelBuilder.Entity<Tickets>().ToTable("Tickets");
            modelBuilder.Entity<Value_Attribute>().ToTable("Value_attribute");

            #endregion
            #region Primary Keys
            
            modelBuilder.Entity<Attribute_Category>().HasKey(attributeCategory => attributeCategory.ID);
            modelBuilder.Entity<Category>().HasKey(category => category.ID);
            modelBuilder.Entity<Chat>().HasKey(chat => chat.ID);
            modelBuilder.Entity<Comment>().HasKey(comment => comment.ID);
            modelBuilder.Entity<Helpful>().HasKey(helpful => helpful.ID);
            modelBuilder.Entity<Messages>().HasKey(messages => messages.ID);
            modelBuilder.Entity<Product>().HasKey(product => product.ID);
            modelBuilder.Entity<Product_Application>().HasKey(productApplication => productApplication.ID);
            modelBuilder.Entity<Product_List>().HasKey(productList => productList.ID);
            modelBuilder.Entity<Product_Rating>().HasKey(productRating => productRating.ID);
            modelBuilder.Entity<Purchased>().HasKey(purchased => purchased.ID);
            modelBuilder.Entity<Reason>().HasKey(reason => reason.ID);
            modelBuilder.Entity<Reports>().HasKey(reports => reports.ID);
            modelBuilder.Entity<Seller_Application>().HasKey(sellerApplication => sellerApplication.ID);
            modelBuilder.Entity<Seller_Rating>().HasKey(sellerRating => sellerRating.ID);
            modelBuilder.Entity<State>().HasKey(state => state.ID);
            modelBuilder.Entity<Tickets>().HasKey(tickets => tickets.ID);
            modelBuilder.Entity<Value_Attribute>().HasKey(valueAttribute => valueAttribute.ID);

            #endregion

            #region Relationships



            #endregion
        }
    }
}
