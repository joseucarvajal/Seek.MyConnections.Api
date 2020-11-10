using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeekQ.MyConnections.Api.Domain.ConnectionsAggregate;

namespace SeekQ.MyConnections.Api.Infrastructure.EntityConfigurations
{
    public class ConnectionEntityConfiguration : IEntityTypeConfiguration<Connection>
    {
        public void Configure(EntityTypeBuilder<Connection> builder)
        {
            builder.ToTable("Connections");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.IdUser)
                .IsRequired(true);

            builder.Property(c => c.ConnectionUserId)
                .IsRequired(true);

            builder.HasIndex(c => new { c.IdUser, c.ConnectionUserId }).IsUnique();

            builder.Property(c => c.Blocked)
                .IsRequired(true);

            builder.Property(c => c.ConnectionNickName)
                .HasMaxLength(20)
                .IsRequired(true);

            builder.Property(c => c.ConnectionFirstName)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(c => c.ConnectionIsFirstNameVisible)
                .IsRequired(true);

            builder.Property(c => c.ConnectionLastName)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(c => c.ConnectionIsLastNameVisible)
                .IsRequired(true);

            builder.Property(c => c.ConnectionAge)
                .HasMaxLength(3)
                .IsRequired(true);

            builder.Property(c => c.ConnectionIsAgeVisible)
                .IsRequired(true);

            builder.Property(c => c.ConnectionAvatar)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.Property(c => c.ConnectionIsAvatar)
                .IsRequired(true);

            builder.Property(c => c.Blocked)
                .IsRequired(true);
        }
    }
}
