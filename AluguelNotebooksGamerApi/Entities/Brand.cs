using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelNotebooksGamerApi.Entities
{
    public class Brand : BaseClass, IEntityTypeConfiguration<Brand>
    {
        public Brand() : base() { }
        public Brand(string? name, string? country, List<Model>? models) : this()
        {
            Name = name;
            Country = country;
            Models = models;
        }

        public string? Name { get; private set; }
        public string? Country { get; private set; }
        public List<Model>? Models { get; private set; }

        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).IsRequired();
        }
    }
}
