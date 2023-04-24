using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleConfigureation : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "b83d673a-b3f9-4e0a-826b-fbd354eb3aeb",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                     ConcurrencyStamp = "d9c621fd-8c58-46d4-9bc9-edb28305a01a"
                },
                new IdentityRole
                {
                    Id= "a0c47c40-f010-4da7-bf7c-bb1772a0c45f",
                    Name = "GoldenUser",
                    NormalizedName = "GOLDENUSER",
                    ConcurrencyStamp = "e0ed4887-65e1-4867-aadf-51a469e5156a"
                }

            );
        }
    }
}
