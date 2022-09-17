using Domain.Common;
using Domain.Entities.Transactions;


namespace Domain.Entities.Users
{
    public class Customer: BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string SureName { get; private set; }
        public Customer()
        {

        }
        public Customer(string name, string sureName )
        {
            Name = name;
            SureName = sureName;
        }
        public Customer Update(string name, string sureName)
        {
            Name=name;
            SureName=sureName;
            return this;
        }
    }
}
