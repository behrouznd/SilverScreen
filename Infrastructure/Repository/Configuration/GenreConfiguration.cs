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
            builder.HasData(new Genre() { Id = new  Guid("FCFC6E62-A435-4B77-803C-35C7BAF29F1A") , Name = "درام" },
                new Genre() { Id =new Guid("4EE6FD25-11D4-41AA-8557-FE75C27292F0"), Name = "کمدی" },
                new Genre() { Id =new Guid("9977591C-8120-4200-885A-68AEEF8D0EE9"), Name = "هیجان اگیز" },
                new Genre() { Id =new Guid("4B09B3CD-C550-4E3E-9892-D1EA7FBA319B"), Name = "عاشقانه" },
                new Genre() { Id =new Guid("F6942543-0205-48A8-BDD9-88EEA9A8FCF9"), Name = "اکشن" },
                new Genre() { Id =new Guid("3CB0336D-C986-409B-85C8-E4F99B56C9C6"), Name = "مستند" },
                new Genre() { Id =new Guid("48476C5E-79F9-43A3-9973-D402C63E8AD6"), Name = "جنایی" },
                new Genre() { Id =new Guid("EF8D754E-C05E-4356-8357-CB986C0D19E9"), Name = "ترسناک" },
                new Genre() { Id =new Guid("2A08F327-753C-49B8-A507-21D7745CB8CA"), Name = "ماجراجویی" },
                new Genre() { Id =new Guid("8C7A55E8-6413-47C8-A57A-F640976E91B7"), Name = "معمایی" },
                new Genre() { Id =new Guid("74B74E60-05F9-4068-A0B2-9F4CE36594ED"), Name = "خانوادگی" },
                new Genre() { Id =new Guid("3D84F61B-C1C0-419B-A8E7-9979A537063D"), Name = "فانتزی" },
                new Genre() { Id =new Guid("B6617ED6-9B80-42F0-B097-D17AA4C1E6C6"), Name = "علمی تخیلی" },
                new Genre() { Id =new Guid("AF4E8811-1442-42B5-B717-52F47F4824DA"), Name = "انیمیشن" },
                new Genre() { Id =new Guid("10278DE4-B04B-4CF5-AF6C-28036F3CC7BE"), Name = "تاریخی" },
                new Genre() { Id =new Guid("5CAF13ED-B026-49C1-9CF7-DA53B5A81D97"), Name = "زندگی نامه" },
                new Genre() { Id =new Guid("75FDF7E2-D961-4BFE-AB0C-A151F2B41703"), Name = "جنگی" },
                new Genre() { Id =new Guid("A3B1337F-C000-4251-9AE5-ECE1D56678CD"), Name = "موزیکال" },
                new Genre() { Id =new Guid("DADD483E-36E3-432D-AD59-2D53ECD9478E"), Name = "ورزشی" },
                new Genre() { Id =new Guid("90BB57EE-81FC-46B2-9FED-6E80711B0CED"), Name = "وسترن" },
                new Genre() { Id =new Guid("9DAA5715-2912-43A5-8682-75DEAC25BA82"), Name = "رئالیتی شو" }          
                );
        }
    }
}
