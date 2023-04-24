using Entities.Languages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasData(new Language { Id =  new Guid("BBF003AE-7612-43C7-A4C1-798CAE797901"), Name = "آلمانی", Image = "" },
                new Language { Id = new Guid("5A53220B-2FBD-42FC-ADEB-876333E0E155"), Name = "انگلیسی", Image = "" }
                  );
        }
    }
}
