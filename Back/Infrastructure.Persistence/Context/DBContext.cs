using Core.Domain.Common;
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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "Admins";
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdatedDate = DateTime.Now;
                        entry.Entity.LastUpdatedBy = "Admin";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

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
            modelBuilder.Entity<Attribute_Category>()
                .HasMany(value => value.Value_Attributes)
                .WithOne(attribute => attribute.Attribute_Category)
                .HasForeignKey(attribute => attribute.AttributeCategoryID)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Category>()
                .HasMany(category => category.Attribute_Categories)
                .WithOne(attribute => attribute.Category)
                .HasForeignKey(attribute => attribute.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>()
                .HasMany(category => category.Products)
                .WithOne(product => product.Category)
                .HasForeignKey(product => product.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(product=>product.Comments)
                .WithOne(comment=>comment.Product)
                .HasForeignKey(comment => comment.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(product=>product.Product_Lists)
                .WithOne(productList=>productList.Product)
                .HasForeignKey(productList => productList.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(product => product.Tickets)
                .WithOne(tickets => tickets.Product)
                .HasForeignKey(tickets => tickets.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(product => product.Product_Applications)
                .WithOne(productApplication => productApplication.Product)
                .HasForeignKey(productApplication => productApplication.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .HasMany(product => product.Product_Images)
                .WithOne(productImages => productImages.Product)
                .HasForeignKey(productImages => productImages.ProductID)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<State>()
            //    .HasMany(state => state.Purchaseds)
            //    .WithOne(purchased => purchased.State)
            //    .HasForeignKey(purchased => purchased.StateID)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<State>()
              .HasMany(state => state.Products)
              .WithOne(product => product.State)
              .HasForeignKey(product=> product.StateID)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
              .HasMany(comment => comment.Helpfuls)
              .WithOne(helpful => helpful.Comment)
              .HasForeignKey(helpful => helpful.CommentID)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Chat>()
              .HasMany(chat => chat.Messages)
              .WithOne(message => message.Chat)
              .HasForeignKey(message => message.ChatID);

            modelBuilder.Entity<Reason>()
              .HasMany(reason => reason.Tickets)
              .WithOne(ticket => ticket.Reason)
              .HasForeignKey(ticket => ticket.ReasonID)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reason>()
             .HasMany(reason => reason.Reports)
             .WithOne(report => report.Reason)
             .HasForeignKey(report => report.ReasonID)
             .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }
    }
}
