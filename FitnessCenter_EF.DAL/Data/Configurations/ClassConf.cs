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
    public class ClassConf : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.HasKey(c => c.ClassId);
            builder
                .HasOne(c => c.Instructor)
                .WithMany(i => i.Classes)
                .HasForeignKey(c => c.InstructorId);
            builder
                .HasMany(c => c.Attendances)
                .WithOne(a => a.Class)
                .HasForeignKey (a => a.ClassId);
            builder
                .HasMany(c => c.Bookings)
                .WithOne(b => b.Class)
                .HasForeignKey (b => b.ClassId);
            builder
                .HasMany(c => c.EquipmentClass)
                .WithOne(ec => ec.Class)
                .HasForeignKey (ec => ec.ClassId);
        }
    }
}
