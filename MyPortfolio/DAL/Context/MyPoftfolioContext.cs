﻿using Microsoft.EntityFrameworkCore;
using MyPortfolio.DAL.Entities;


namespace MyPortfolio.DAL.Context
{
    public class MyPoftfolioContext : DbContext
    {
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-363RU31\\SQLEXPRESS;initial Catalog=MyPortfolioDb;integrated Security=true;");

        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasIndex(x => x.UserName)
                .IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(x => x.Mail)
                .IsUnique();      
		}
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
	}
}
