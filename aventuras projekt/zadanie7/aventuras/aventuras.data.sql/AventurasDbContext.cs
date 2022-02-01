using aventuras.data.sql.DAO;
using aventuras.data.sql.DAOConfigurations;
using Microsoft.EntityFrameworkCore;

namespace aventuras.data.sql
{
    public class AventurasDbContext : DbContext
    {

        public AventurasDbContext(DbContextOptions<AventurasDbContext> options) : base(options) { }

        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Post> Post { get; set; }
        public virtual DbSet<DAO.Rating> Rating { get; set; }
        public virtual DbSet<DAO.Share> Share { get; set; }
        public virtual DbSet<DAO.User> User { get; set; }
        public virtual DbSet<VisualMedia> VisualMedia { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
            builder.ApplyConfiguration(new RatingConfiguration());
            builder.ApplyConfiguration(new ShareConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new VisualMediaConfiguration());
        }
    }
}
