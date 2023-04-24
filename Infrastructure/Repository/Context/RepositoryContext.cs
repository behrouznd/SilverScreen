using Entities.Categories;
using Entities.Genres;
using Entities.Languages;
using Entities.Movies;
using Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;

namespace Repository.Context
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LanguageConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfigureation());
        }


        public DbSet<Language>? Languages { get; set; }
        public DbSet<Genre>? Genres { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie>? Movies { get; set; }
        public DbSet<MovieFile>? MovieFiles { get; set; }
        public DbSet<MovieGenre>? MovieGenres { get; set; }
        public DbSet<MovieLanguage>? MovieLanguages { get; set; }

    }
}
