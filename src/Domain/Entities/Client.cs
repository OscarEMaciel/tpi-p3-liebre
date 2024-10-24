using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client : User
    {
        public List<Transaction> Transactions { get; set; }
    }
}

