using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelNotebooksGamerApi.Entities
{
    public class Rented : BaseClass, IEntityTypeConfiguration<Rented>
    {
        public DateTime Period { get; private set; }
        public Decimal ValuePerHour { get; private set; }
        public Decimal TotalValue { get; private set; }
        public List<Client>? Client { get; private set; }
        public List<Model>? Model { get; private set; }

        public Rented() : base()
        {

        }
        public Rented(DateTime period, decimal valuePerHour, decimal totalValue) : this()
        {
            Period = period;
            ValuePerHour = valuePerHour;
            TotalValue = totalValue;
        }

        public void Configure(EntityTypeBuilder<Rented> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).IsRequired();
        }
    }
}
