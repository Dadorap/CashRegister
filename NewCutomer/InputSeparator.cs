using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.NewCutomer
{
    public class InputSeparator
    {
        //a tuple that does string manipulation and also convert string to int and return id and amount as integer of user input
        public static (int prodId, int amount) GetIdAmount(string userInput)
        {
            string[] userParts = userInput.Split(" ");

            int prodId = int.Parse(userParts[0]);
            int amount = int.Parse(userParts[1]);

            return (prodId, amount);
        }
    }
}
