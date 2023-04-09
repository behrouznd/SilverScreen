using Entities.Genres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData(new Genre() { Id = Guid.NewGuid() , Name = "درام" },
                new Genre() { Id = Guid.NewGuid(), Name = "کمدی" },
                new Genre() { Id = Guid.NewGuid(), Name = "هیجان اگیز" },
                new Genre() { Id = Guid.NewGuid(), Name = "عاشقانه" },
                new Genre() { Id = Guid.NewGuid(), Name = "اکشن" },
                new Genre() { Id = Guid.NewGuid(), Name = "مستند" },
                new Genre() { Id = Guid.NewGuid(), Name = "جنایی" },
                new Genre() { Id = Guid.NewGuid(), Name = "ترسناک" },
                new Genre() { Id = Guid.NewGuid(), Name = "ماجراجویی" },
                new Genre() { Id = Guid.NewGuid(), Name = "معمایی" },
                new Genre() { Id = Guid.NewGuid(), Name = "خانوادگی" },
                new Genre() { Id = Guid.NewGuid(), Name = "فانتزی" },
                new Genre() { Id = Guid.NewGuid(), Name = "علمی تخیلی" },
                new Genre() { Id = Guid.NewGuid(), Name = "انیمیشن" },
                new Genre() { Id = Guid.NewGuid(), Name = "تاریخی" },
                new Genre() { Id = Guid.NewGuid(), Name = "زندگی نامه" },
                new Genre() { Id = Guid.NewGuid(), Name = "جنگی" },
                new Genre() { Id = Guid.NewGuid(), Name = "موزیکال" },
                new Genre() { Id = Guid.NewGuid(), Name = "ورزشی" },
                new Genre() { Id = Guid.NewGuid(), Name = "وسترن" },
                new Genre() { Id = Guid.NewGuid(), Name = "رئالیتی شو" }          
                );
        }
    }
}
