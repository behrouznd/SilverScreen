using Entities.Categories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category() { Id = new Guid("A653E850-EEAF-45F4-9E03-F81E3AC64278") , Name = "فیلم" },
                new Category() { Id = new Guid("73E8B4D5-016B-4DAE-851A-4D4335F9AA8F") , Name = "سریال"});
        }
    }
}
