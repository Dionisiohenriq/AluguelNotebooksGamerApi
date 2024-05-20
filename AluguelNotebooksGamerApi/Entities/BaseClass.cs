using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelNotebooksGamerApi.Entities
{
    public class BaseClass : IEntityTypeConfiguration<BaseClass>
    {
        public Guid Id { get; private set; }
        public bool Excluded { get; private set; }
        public BaseClass()
        {
            Id = Guid.NewGuid();
        }

        public void Delete()
        {
            Excluded = true;
        }

        public void Configure(EntityTypeBuilder<BaseClass> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
        }
    }
}
