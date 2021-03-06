namespace Model.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShopdbContext : DbContext
    {
        public ShopdbContext()
            : base("name=ShopdbContext")
        {
        }

        public virtual DbSet<Advertise> Advertises { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product_Details> Product_Details { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<ShopInfo> ShopInfoes { get; set; }
        public virtual DbSet<Support> Supports { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<View_ProductDetails> View_ProductDetails { get; set; }
        public virtual DbSet<View_ShopProductInfo> View_ShopProductInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>()
                .HasMany(e => e.Product_Details)
                .WithOptional(e => e.Brand)
                .HasForeignKey(e => e.Brand_Id);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Districts)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.City_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.ShopInfoes)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.City_Id);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.City_Id);

            modelBuilder.Entity<City>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.City)
                .HasForeignKey(e => e.Delivery_City_Id);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Contact>()
                .Property(e => e.Mail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.District)
                .HasForeignKey(e => e.District_Id);

            modelBuilder.Entity<District>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.District)
                .HasForeignKey(e => e.Delivery_District_Id);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.Order_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product_Details>()
                .Property(e => e.ProductDimension)
                .IsUnicode(false);

            modelBuilder.Entity<Product_Details>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product_Details)
                .HasForeignKey(e => e.Product_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Product_Details)
                .WithOptional(e => e.ProductType)
                .HasForeignKey(e => e.ProductType_Id);

            modelBuilder.Entity<ShopInfo>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Support>()
                .Property(e => e.Tel)
                .IsUnicode(false);

            modelBuilder.Entity<Support>()
                .Property(e => e.Nick)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PW)
                .IsUnicode(false);

            modelBuilder.Entity<View_ProductDetails>()
                .Property(e => e.ProductDimension)
                .IsUnicode(false);
        }
    }
}
