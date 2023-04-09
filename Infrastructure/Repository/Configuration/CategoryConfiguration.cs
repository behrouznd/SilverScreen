using Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category() { Id = Guid.NewGuid() , Name = "فیلم" },
                new Category() { Id = Guid.NewGuid() , Name = "سریال"});
        }
    }
}
