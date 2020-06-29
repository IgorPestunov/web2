using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web2.Models
{
    public class OperationsModel
    {
        public int value1 { get; set; }
        public int value2 { get; set; }
        public int result { get; set; }
        public string operation  { get; set; }

        public void compute() 
        { 
            switch (operation)
            {
                case "+":
                    result = value1 + value2;
                    break;
                case "-":
                    result = value1 - value2;
                    break;
                case "/":
                    if (value2 != 0)
                    { result = value1 / value2; break; }
                    else
                    { result = -1; break; } // -1 будет при делении на 0
                case "*":
                    result = value1 * value2;
                    break;                    
            }
                
    }
    }
}
