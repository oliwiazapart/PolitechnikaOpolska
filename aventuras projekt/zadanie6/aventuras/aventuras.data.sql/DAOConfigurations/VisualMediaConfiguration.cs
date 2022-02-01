using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using aventuras.data.sql.DAO;

namespace aventuras.data.sql.DAOConfigurations
{
    public class VisualMediaConfiguration : IEntityTypeConfiguration<VisualMedia>
    {
        public void Configure(EntityTypeBuilder<VisualMedia> builder)
        {
            builder.Property(c => c.VMediaHref).IsRequired(); 
            builder.Property(c => c.VMediaType).IsRequired();
            builder.HasOne(x => x.Post)
                .WithMany(x => x.VisualMedias)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PostId);
            builder.ToTable("Visual Media");
        }

    }
}
