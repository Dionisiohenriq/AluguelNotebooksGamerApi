using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelNotebooksGamerApi.Entities
{
    public class Model : BaseClass
    {
        public Model() : base() { }
        public Model(bool rented, string? name, decimal value, Brand? brand, ModelConfiguration? modelConfiguration) : this()
        {
            Rented = rented;
            Name = name;
            Value = value;
            Brand = brand;
            ModelConfiguration = modelConfiguration;
        }

        public bool Rented { get; private set; }
        public string? Name { get; private set; }
        public decimal Value { get; private set; }
        public Brand? Brand { get; private set; }
        public ModelConfiguration? ModelConfiguration { get; private set; }

        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.HasBaseType(typeof(BaseClass));
        }
    }
}
