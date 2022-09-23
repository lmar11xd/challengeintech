using InTech.Core.Entities.Base;

namespace InTech.Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
