using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using aventuras.data.sql.DAO;

namespace aventuras.data.sql.DAOConfigurations
{
    public class ShareConfiguration: IEntityTypeConfiguration<Share>
    {
        public void Configure(EntityTypeBuilder<Share> builder)
        {
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Shares)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.User)
                .WithMany(x => x.Shares)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.ToTable("Share");
        }
    }
}
