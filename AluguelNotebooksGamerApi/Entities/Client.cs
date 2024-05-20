using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AluguelNotebooksGamerApi.Entities
{
    public class Client : BaseClass
    {
        public Client() : base() { }
        public Client(string firstName, int age, string? document, string? contact, string? email, Address address, string? lastName) : this()
        {
            FirstName = firstName;
            Age = age;
            Document = document;
            Contact = contact;
            Email = email;
            Address = address;
            LastName = lastName;
        }

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public int Age { get; private set; }
        public string? Document { get; private set; }
        public string? Contact { get; private set; }
        public string? Email { get; private set; }
        public Address? Address { get; private set; }

        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasBaseType(typeof(BaseClass));
        }
    }
}
