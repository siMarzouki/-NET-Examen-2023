using App.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Configurations
{
    internal class KafalaConfiguration : IEntityTypeConfiguration<Kafala>
    {
        public void Configure(EntityTypeBuilder<Kafala> builder)
        {
            builder.HasOne(e => e.Beneficiary).WithMany(e => e.kafalas).HasForeignKey(e => e.BeneficiaryCIN);
            builder.HasOne(e => e.Donator).WithMany(e => e.Kafalas).HasForeignKey(e => e.DonatorId);
            builder.HasKey(e => new { e.StartDate, e.BeneficiaryCIN, e.DonatorId });

        }
    }
}
