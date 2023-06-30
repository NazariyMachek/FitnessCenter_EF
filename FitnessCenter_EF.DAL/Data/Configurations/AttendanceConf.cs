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
    public class AttendanceConf : IEntityTypeConfiguration<Attendance>
    {
        public void Configure(EntityTypeBuilder<Attendance> builder)
        {
            builder.HasKey(a => a.AttendanceId);
            builder
                .HasOne(a => a.Customer)
                .WithMany(c => c.Attendances)
                .HasForeignKey(c => c.AttendanceId);
            builder
                .HasOne(a => a.Class)
                .WithMany(c => c.Attendances)
                .HasForeignKey(c => c.AttendanceId);
        }
    }
}
