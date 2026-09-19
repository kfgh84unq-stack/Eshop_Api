using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.SiteEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructur.persistent.EF.SiteEntities
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(b => b.ImageName)
                     .HasMaxLength(120).IsRequired();

            builder.Property(b => b.Title)
                    .HasMaxLength(120);

            builder.Property(b => b.Link)
                .HasMaxLength(500);
        }
    }
}
