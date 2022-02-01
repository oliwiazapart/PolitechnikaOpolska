using aventuras.data.sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAOConfigurations
{
    public class ShareConfiguration : IEntityTypeConfiguration<DAO.Share>
    {
        public void Configure(EntityTypeBuilder<DAO.Share> builder)
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
