using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Domain.Entities
{
    public class Client : User
    {
        public List<Transaction> Transactions { get; set; }


    }
}

