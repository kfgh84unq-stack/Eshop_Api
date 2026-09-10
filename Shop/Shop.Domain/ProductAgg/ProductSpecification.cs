using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductSpecification:BaseEntity
    {
        public ProductSpecification(string key, string value)
        {
            NullOrEmptyDomainDataException.CheckString(key, nameof(key));
            NullOrEmptyDomainDataException.CheckString(value, nameof(value));

            Key = key;
            Value = value;
        }

        public long ProductId { get; internal set; }
        public string Key { get; internal set; }
        public string Value { get; internal set; }

    }
}
