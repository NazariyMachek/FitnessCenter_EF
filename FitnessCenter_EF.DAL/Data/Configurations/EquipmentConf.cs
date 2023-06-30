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
    public class EquipmentConf : IEntityTypeConfiguration<Equipment>
    {
        public void Configure(EntityTypeBuilder<Equipment> builder)
        {
            builder.HasKey(e => e.EquipmentId);
            builder
                .HasMany(e => e.EquipmentClass)
                .WithOne(ec => ec.Equipment)
                .HasForeignKey(ec => ec.EquipmentId);
        }
    }
}
