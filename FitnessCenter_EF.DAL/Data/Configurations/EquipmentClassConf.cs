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
    public class EquipmentClassConf : IEntityTypeConfiguration<EquipmentClass>
    {
        public void Configure(EntityTypeBuilder<EquipmentClass> builder)
        {
            builder
                .HasOne(ec => ec.Equipment)
                .WithMany(e => e.EquipmentClass)
                .HasForeignKey(ec => ec.EquipmentId);

            builder
                .HasOne(ec => ec.Class)
                .WithMany(c => c.EquipmentClass)
                .HasForeignKey(ec => ec.ClassId);
        }
    }
}
