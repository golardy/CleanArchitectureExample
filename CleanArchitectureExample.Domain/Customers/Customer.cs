using CleanArchitectureExample.Domain.Abstractions;

namespace CleanArchitectureExample.Domain.Customers
{
    public sealed class Customer : IAuditableEntity
    {
        public DateTime CreatedOnUtc { get; }

        public DateTime? ModifiedOnUtc { get; }

        public Customer(DateTime creacted) 
        {
            CreatedOnUtc = creacted;
        }
    }
}
