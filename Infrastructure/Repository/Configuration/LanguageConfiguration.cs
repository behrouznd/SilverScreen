using Entities.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(new Language { Id =   Guid.NewGuid(), Name = "آلمانی", Image = "" },
                new Language { Id = Guid.NewGuid(), Name = "انگلیسی", Image = "" }
                  );
        }
    }
}
