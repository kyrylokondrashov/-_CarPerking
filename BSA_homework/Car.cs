using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA_homework
{
    enum carType
    {
        passanger,
        truck,
        bus,
        motorcycle
    }
    class Car
    {
        public uint currentID { get; private set; }

        public carType currentType { get; private set; }

        public float currentBalance { get; private set; }
        
        public Car(uint id, carType type, float balance)
        {
            currentID = id;
            currentType = type;
            currentBalance = balance;
        }

        public float addToBalance(float someMoney)
        {
            currentBalance += someMoney;
            return currentBalance;
        }

        public float removeFromBalance(float someMoney)
        {
            currentBalance -= someMoney;
            return currentBalance;
        }
    }
    
}
