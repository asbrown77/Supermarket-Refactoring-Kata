using System;

namespace Supermarket.model
{
    public class Product : IEquatable<Product>
    {
        public string Name { get; }
        public ProductUnitType UnitType { get; }

        public Product(string name, ProductUnitType unitType)
        {
            this.Name = name;
            this.UnitType = unitType;
        }

        public bool Equals(Product other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name) && Equals(UnitType, other.UnitType);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Product) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0) * 397) ^ (UnitType != null ? UnitType.GetHashCode() : 0);
            }
        }
    }
}
