using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA_homework
{
    class Transaction
    {
        public DateTime tranactionDate { get; }
        public uint curId { get; }

        public float moneyRemobeBalance { get; }

        public Transaction (uint id, float money, DateTime date)
        {
            curId = id;
            moneyRemobeBalance = money;
            tranactionDate = date;
        }

    }
}
