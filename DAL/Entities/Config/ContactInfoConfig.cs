using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Entities.Config
{
    internal class ContactInfoConfig : IEntityTypeConfiguration<ContactInfo>
    {
        public void Configure(EntityTypeBuilder<ContactInfo> builder)
        {
            builder.ToTable("contact_infos");

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseMySqlIdentityColumn(); ;

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(x => x.IsMarried)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(x => x.Phone)
             .IsRequired();

            builder.Property(x => x.Salary)
             .IsRequired()
             .HasColumnType("decimal(19,2)");
        }
    }
}
