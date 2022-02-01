using aventuras.data.sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAOConfigurations
{
    public class RatingConfiguration : IEntityTypeConfiguration<DAO.Rating>
    {
        public void Configure(EntityTypeBuilder<DAO.Rating> builder)
        {
            builder.Property(c => c.NumericRating).IsRequired();
            builder.Property(c => c.UsefulStatus).HasColumnType("tinyint(1)");
            builder.HasOne(x => x.User)
                .WithMany(x => x.Ratings)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Ratings)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.CommentComment)
                 .WithMany(x => x.Ratings)
                 .OnDelete(DeleteBehavior.Restrict)
                 .HasForeignKey(x => x.CommentId);
            builder.ToTable("Rating");
        }
    }
}
