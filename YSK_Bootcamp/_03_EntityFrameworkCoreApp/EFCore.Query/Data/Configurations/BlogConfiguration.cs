using EFCore.Query.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Query.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(250);

            builder.Property(x => x.Url).HasMaxLength(300);
        }
    }
}
