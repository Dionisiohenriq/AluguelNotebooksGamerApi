using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelNotebooksGamerApi.Entities
{
    public class Address : BaseClass, IEntityTypeConfiguration<Address>
    {
        public Address() : base() { }
        public Address(int number, string? street, string? neighborhood, string? city, string? country) : this()
        {
            Number = number;
            Street = street;
            Neighborhood = neighborhood;
            City = city;
            Country = country;
        }

        public int Number { get; private set; }
        public string? Street { get; private set; }
        public string? Neighborhood { get; private set; }
        public string? City { get; private set; }
        public string? Country { get; private set; }

        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).IsRequired();
        }
    }
}
