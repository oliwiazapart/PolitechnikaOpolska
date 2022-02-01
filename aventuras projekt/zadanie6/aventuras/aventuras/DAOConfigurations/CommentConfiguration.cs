using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using aventuras.data.sql.DAO;

namespace aventuras.data.sql.DAOConfigurations
{
    public class CommentConfiguration: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.CommentBody).IsRequired();
            builder.Property(c => c.ActiveStatus).HasColumnType("tinyint(1)");
            builder.HasOne(x => x.CommentComment)
                .WithMany(x => x.SubComments)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.CommentCommentId);

            builder.ToTable("Comment");
        }
    }
}
