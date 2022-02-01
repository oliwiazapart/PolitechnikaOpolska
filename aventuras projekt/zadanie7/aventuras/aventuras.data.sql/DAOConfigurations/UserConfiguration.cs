using aventuras.data.sql.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace aventuras.data.sql.DAOConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<DAO.User>
    {
        public void Configure(EntityTypeBuilder<DAO.User> builder)
        {
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.BirthDate).IsRequired();
            builder.Property(c => c.ActiveStatus).HasColumnType("tinyint(1)");
            builder.ToTable("User");
        }
    }
}
