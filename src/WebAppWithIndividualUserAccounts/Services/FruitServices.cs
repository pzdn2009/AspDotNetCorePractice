using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithIndividualUserAccounts.Services
{
    public class FruitServices
    {
        public List<string> GetFruits()
        {
            return new List<string>() { "Mango", "Apple", "Apricot", "Banana", "Grapes" };
        }
    }
}
