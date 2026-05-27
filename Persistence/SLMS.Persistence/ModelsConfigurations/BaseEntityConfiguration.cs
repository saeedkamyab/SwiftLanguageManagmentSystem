using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SLMS.ApplicationCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SLMS.Persistence.ModelsConfigurations
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreateDate).IsRequired();
            builder.Property(x => x.CreatedById).IsRequired();
            builder.Property(x => x.LastUpdate).IsRequired(false);
            builder.Property(x => x.LastUpdatedById).IsRequired(false);
        }
    }
}
