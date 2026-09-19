using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infrastructur.persistent.EF.RoleAgg
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles", "role");

            builder.Property(b=>b.Title)
                .IsRequired().HasMaxLength(60);

            builder.OwnsMany(b => b.RolePermissions, option =>
            {
                option.ToTable("RolePermissions", "role");
            });
        }
    }
}
