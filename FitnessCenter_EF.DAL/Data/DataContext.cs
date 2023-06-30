using FitnessCenter_EF.DAL.Models;
using FitnessCenter_EF.DAL.Data.Configurations;
using FitnessCenter_EF.DAL.InsertData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<EquipmentClass > EquipmentClasses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AttendanceConf());
            modelBuilder.ApplyConfiguration(new BookingConf());
            modelBuilder.ApplyConfiguration(new ClassConf());
            modelBuilder.ApplyConfiguration(new CustomerConf());
            modelBuilder.ApplyConfiguration(new EquipmentClassConf());
            modelBuilder.ApplyConfiguration(new EquipmentConf());
            modelBuilder.ApplyConfiguration(new InstructorConf());
            modelBuilder.ApplyConfiguration(new SubscriptionConf());


            DataGenerator.Generate();
            modelBuilder.Entity<Attendance>().HasData(DataGenerator.Attendances);
            modelBuilder.Entity<Booking>().HasData(DataGenerator.Bookings);
            modelBuilder.Entity<Class>().HasData(DataGenerator.Classes);
            modelBuilder.Entity<Customer>().HasData(DataGenerator.Customers);
            modelBuilder.Entity<EquipmentClass>().HasData(DataGenerator.EquipmentClasses);
            modelBuilder.Entity<Equipment>().HasData(DataGenerator.Equipment);
            modelBuilder.Entity<Instructor>().HasData(DataGenerator.Instructors);
            modelBuilder.Entity<Subscription>().HasData(DataGenerator.Subscriptions);
        }
    }
}
