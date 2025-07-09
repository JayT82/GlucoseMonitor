using GlucoseMonitor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlucoseMonitor.Infrastructure.Persistence.Configurations
{
    public class MeasurementConfiguration : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable("Measurements");

            builder.HasKey(m => m.Id);

            builder.Property(m => m.Id)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(m => m.PatientId)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(m => m.Type)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(m => m.Value)
                   .IsRequired();

            builder.Property(m => m.Unit)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(m => m.Timestamp)
                   .IsRequired();
        }
    }
}
