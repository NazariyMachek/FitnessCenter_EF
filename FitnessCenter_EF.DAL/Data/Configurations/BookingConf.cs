using FitnessCenter_EF.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessCenter_EF.DAL.Data.Configurations
{
    public class BookingConf : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.BookingId);
            builder
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(c => c.BookingId);
            builder
                .HasOne(b => b.Class)
                .WithMany(c => c.Bookings)
                .HasForeignKey(c => c.BookingId);
        }
    }
}
